using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using SR = System.Reflection;

namespace Insider
{
    /// <summary>
    /// Class used to weave modules.
    /// </summary>
    [Serializable]
    public sealed partial class Weaver : MarshalByRefObject, IDisposable
    {
        public const string ASSEMBLY_NAME = "Insider";

        /// <summary>
        /// Module being woven.
        /// </summary>
        public readonly ModuleDefinition Module;

        /// <summary>
        /// Assembly being woven.
        /// </summary>
        public readonly SR.Assembly Assembly;

        /// <summary>
        /// Settings set by the assembly being woven.
        /// </summary>
        public readonly Dictionary<string, object> Settings;

        /// <summary>
        /// Path of the assembly that'll be written.
        /// </summary>
        public readonly string TargetPath;

        /// <summary>
        /// If <code>true</code>, a message whose importance is
        /// <see cref="MessageImportance.Warning"/> will stop the
        /// weaving process.
        /// </summary>
        public bool TreatWarningsAsErrors { get; set; }

        /// <summary>
        /// Event triggered when a weaver calls <see cref="WeaverAttribute.Log(string, MessageImportance)"/>.
        /// </summary>
        public event Action<MessageLoggedEventArgs> MessageLogged;

        /// <summary>
        /// Collection of all assemblies referenced, classed by name
        /// (<see cref="SR.AssemblyName.Name"/>).
        /// </summary>
        private readonly Dictionary<string, Tuple<SR.Assembly, AssemblyDefinition>> Assemblies;

        /// <summary>
        /// List of all module weavers found in every scanned assembly.
        /// </summary>
        private readonly List<IModuleWeaver> ModuleWeavers;

        /// <summary>
        /// <see cref="Delegate"/> that calls <see cref="LogMessage(string, MessageImportance)"/>.
        /// </summary>
        private Delegate LogMessageDelegate;

        /// <summary>
        /// Whether or not <see cref="ModuleDefinition.ReadSymbols"/> was successful,
        /// in which case <see cref="MethodDefinition.DebugInformation"/> is available.
        /// </summary>
        private readonly bool SymbolsWereRead;

        public bool ShouldCleanUp => GetSetting($"{ASSEMBLY_NAME}.CleanUp", true);

        /// <summary>
        /// Initialize a new <see cref="Weaver"/>, given the path to the
        /// assembly it will weave.
        /// <para>
        /// Please do not call directly.
        /// </para>
        /// </summary>
        /// <param name="filepath">Absolute path of the assembly to weave</param>
        /// <param name="referencedFiles">Absolute paths of the files referenced by the assembly to weave</param>
        public Weaver(string filepath, string targetpath, params string[] referencedFiles)
        {
            filepath = Path.GetFullPath(filepath);
            TargetPath = Path.GetFullPath(targetpath);

            // Resolve assembly, module, and initialize settings
            Module = ModuleDefinition.ReadModule(filepath, new ReaderParameters
            {
                InMemory = true,
                AssemblyResolver = new AssemblyResolver(this)
            });

            try
            {
                // Read symbols for easier debugging
                Module.ReadSymbols();
                SymbolsWereRead = true;
            }
            catch (Exception)
            {
                SymbolsWereRead = false;
            }

            Assembly = ImportAssembly(filepath);

            Assemblies = new Dictionary<string, Tuple<SR.Assembly, AssemblyDefinition>>();
            Settings = new Dictionary<string, object>();
            ModuleWeavers = new List<IModuleWeaver>();

            // Take care of assembly resolving errors, thanks to the given references
            AppDomain.CurrentDomain.AssemblyResolve += DomainAssemblyResolve;

            // Resolve the original Insider assembly, otherwise interacting with this class
            // from another AppDomain will throw.
            SR.Assembly insiderAssembly = SR.Assembly.GetExecutingAssembly();
            Assemblies.Add(ASSEMBLY_NAME, Tuple.Create(insiderAssembly, AssemblyDefinition.ReadAssembly(insiderAssembly.Location)));

            // Set local Weave properties
            Weave.CurrentAssembly = Assembly;
            Weave.CurrentAssemblyDef = Module.Assembly;
            Weave.Assemblies = Assemblies;

            // Import insider settings
            ImportInsiderSettings(Module.Assembly);

            // Retrieve references
            // Import default settings
            foreach (string referencedFile in referencedFiles)
            {
                var assembly = ImportAssembly(referencedFile);
                var assemblyDef = AssemblyDefinition.ReadAssembly(referencedFile);
                
                Assemblies.Add(assemblyDef.Name.Name, Tuple.Create(assembly, assemblyDef));

                ImportDefaultSettings(assemblyDef.MainModule, assembly);
                ImportAssemblySettings(assemblyDef);
                SetAssemblyWeave(assemblyDef, assembly);
            }

            Assemblies.Add(Module.Assembly.Name.Name, Tuple.Create(Assembly, Module.Assembly));

            ImportDefaultSettings(Module, Assembly);
            ImportAssemblySettings(Module.Assembly, true);
            SetAssemblyWeave(Module.Assembly, Assembly);
        }

        /// <summary>
        /// Look through already imported assemblies for
        /// a match.
        /// </summary>
        private SR.Assembly DomainAssemblyResolve(object sender, ResolveEventArgs args)
        {
            SR.AssemblyName assemblyName = new SR.AssemblyName(args.Name);

            if (Assemblies.ContainsKey(assemblyName.Name))
                return Assemblies[assemblyName.Name].Item1;
            return null;
        }

        /// <summary>
        /// Import an assembly, and its settings.
        /// </summary>
        /// <param name="assemblyPath">The path to the file in which the Assembly is located</param>
        private SR.Assembly ImportAssembly(string assemblyPath)
        {
            switch (Path.GetFileName(assemblyPath))
            {
                case "Mono.Cecil.dll":
                    return typeof(AssemblyDefinition).Assembly;
                case "Mono.Cecil.Pdb.dll":
                    return typeof(Mono.Cecil.Pdb.PdbReader).Assembly;
                case "Mono.Cecil.Mdb.dll":
                    return typeof(Mono.Cecil.Mdb.MdbReader).Assembly;
                case "Mono.Cecil.Rocks.dll":
                    return typeof(Mono.Cecil.Rocks.ILParser).Assembly;
                default:
                    return SR.Assembly.LoadFrom(assemblyPath);
            }
        }
        
        /// <summary>
        /// Scan an <see cref="AssemblyDefinition"/>'s custom attributes
        /// for a <see cref="InsiderSettingAttribute"/>.
        /// </summary>
        private void ImportAssemblySettings(AssemblyDefinition assembly, bool mainAssembly = false)
        {
            bool cleanUp = ShouldCleanUp;

            for (int i = 0; i < assembly.CustomAttributes.Count; i++)
            {
                CustomAttribute attr = assembly.CustomAttributes[i];
                TypeDefinition typeDef = attr.AttributeType.AsTypeDefinition();

                if (typeDef == null)
                    continue;

                if (typeDef.Is(typeof(SettingAttribute)))
                {
                    Settings[(string)attr.ConstructorArguments[0].GetValue()] = attr.ConstructorArguments[1].GetValue();

                    if (mainAssembly && cleanUp)
                        assembly.CustomAttributes.RemoveAt(i--);
                }
                else if (attr.AttributeType.Is<InsiderAttribute>(false))
                {
                    if (mainAssembly)
                    {
                        foreach (var field in attr.Fields)
                            Settings[typeDef.Namespace + '.' + field.Name] = field.Argument.GetValue();
                        foreach (var prop in attr.Properties)
                            Settings[typeDef.Namespace + '.' + prop.Name] = prop.Argument.GetValue();

                        if (mainAssembly && cleanUp)
                            assembly.CustomAttributes.RemoveAt(i--);
                    }
                }
                else if (Extends<InsiderSettingAttribute>(attr.AttributeType.AsTypeDefinition()))
                {
                    foreach (var field in attr.Fields)
                        Settings[typeDef.Namespace + '.' + field.Name] = field.Argument.GetValue();
                    foreach (var prop in attr.Properties)
                        Settings[typeDef.Namespace + '.' + prop.Name] = prop.Argument.GetValue();

                    if (mainAssembly && cleanUp)
                        assembly.CustomAttributes.RemoveAt(i--);
                }
            }
        }

        /// <summary>
        /// Import settings related to Insider.
        /// </summary>
        private void ImportInsiderSettings(AssemblyDefinition assembly)
        {
            CustomAttribute attr = assembly.GetAttribute<InsiderAttribute>();

            if (attr != null)
            {
                foreach (var prop in attr.Properties)
                    Settings[$"{ASSEMBLY_NAME}.{prop.Name}"] = prop.Argument.GetValue();

                if (ShouldCleanUp)
                    assembly.CustomAttributes.Remove(attr);
            }
        }

        /// <summary>
        /// Import default settings for every declared attribute that inherits
        /// <see cref="InsiderSettingAttribute"/>.
        /// </summary>
        private void ImportDefaultSettings(ModuleDefinition moduleDef, SR.Assembly assembly)
        {
            bool cleanUp = ShouldCleanUp;

            foreach (TypeDefinition type in moduleDef.Types)
            {
                if (Extends<InsiderSettingAttribute>(type)) // Import default settings
                {
                    foreach (IMemberDefinition member in type.Fields.OfType<IMemberDefinition>().Concat(type.Properties))
                    {
                        CustomAttribute attr = member.GetAttribute<DefaultSettingValueAttribute>();
                        if (attr == null)
                            continue;

                        string name = type.Namespace + '.' + member.Name;
                        if (!Settings.ContainsKey(name))
                            Settings[name] = attr.ConstructorArguments[0].GetValue();

                        if (cleanUp)
                            member.CustomAttributes.Remove(attr);
                    }
                }
                else if (Extends<IModuleWeaver>(type)) // Module weaver
                {
                    Type moduleWeaverType = assembly.GetType(type.FullName);
                    if (moduleWeaverType == null)
                        continue;

                    var ctor = moduleWeaverType.GetConstructor(new Type[0]);
                    if (ctor == null)
                        continue;

                    IModuleWeaver weaver = (IModuleWeaver)ctor.Invoke(new object[0]);
                    ProcessModuleWeaver(moduleWeaverType, weaver, true);

                    ModuleWeavers.Add(weaver);
                }
            }
        }

        /// <summary>
        /// Set the <see cref="Weave.Assemblies"/>, <see cref="Weave.CurrentAssembly"/>
        /// and <see cref="Weave.CurrentAssemblyDef"/> properties of a
        /// given assembly.
        /// </summary>
        private void SetAssemblyWeave(AssemblyDefinition assemblyDef, SR.Assembly assembly)
        {
            Type weaveType = assembly.GetType(typeof(Weave).FullName);

            if (weaveType != null)
            {
                weaveType.GetProperty(nameof(Weave.CurrentAssembly)).SetValue(null, Assembly);
                weaveType.GetProperty(nameof(Weave.CurrentAssemblyDef)).SetValue(null, Module.Assembly);
                weaveType.GetField(nameof(Weave.Assemblies), SR.BindingFlags.Static | SR.BindingFlags.NonPublic).SetValue(null, Assemblies);
            }
        }

        /// <summary>
        /// Dispose all loaded modules.
        /// </summary>
        public void Dispose()
        {
            foreach (var assemblyPair in Assemblies.Values)
                assemblyPair.Item2.Dispose();

            Module.Dispose();
        }
    }
}
