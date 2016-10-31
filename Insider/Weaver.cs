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
        public event EventHandler<MessageLoggedEventArgs> MessageLogged;

        /// <summary>
        /// Collection of all assemblies referenced, classed by name
        /// (<see cref="SR.AssemblyName.Name"/>).
        /// </summary>
        private readonly Dictionary<string, Tuple<SR.Assembly, AssemblyDefinition>> Assemblies;

        /// <summary>
        /// <see cref="Delegate"/> that calls <see cref="LogMessage(string, MessageImportance)"/>.
        /// </summary>
        private Delegate LogMessageDelegate;

        public bool ShouldCleanUp => GetSetting($"{ASSEMBLY_NAME}.CleanUp", true);
        public bool ShouldDebug => GetSetting($"{ASSEMBLY_NAME}.Debug", false);

        /// <summary>
        /// Initialize a new <see cref="Weaver"/>, given the path to the
        /// assembly it will weave.
        /// </summary>
        /// <param name="filepath">Absolute path of the assembly to weave</param>
        /// <param name="referencedFiles">Absolute paths of the files referenced by the assembly to weave</param>
        public Weaver(string filepath, string targetpath, params string[] referencedFiles)
        {
            filepath = Path.GetFullPath(filepath);
            TargetPath = Path.GetFullPath(targetpath);

            // Resolve assembly, module, and initialize settings
            Assembly = ImportAssembly(filepath);
            Module = ModuleDefinition.ReadModule(filepath, new ReaderParameters
            {
                InMemory = true,
                AssemblyResolver = new AssemblyResolver(this)
            });

            Assemblies = new Dictionary<string, Tuple<SR.Assembly, AssemblyDefinition>>();
            Settings = new Dictionary<string, object>();

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

                ImportDefaultSettings(assemblyDef.MainModule);
                ImportAssemblySettings(assemblyDef);

                Assemblies.Add(assemblyDef.Name.Name, Tuple.Create(assembly, assemblyDef));
            }

            ImportDefaultSettings(Module);
            ImportAssemblySettings(Module.Assembly, true);

            Assemblies.Add(Module.Assembly.Name.Name, Tuple.Create(Assembly, Module.Assembly));
        }

        /// <summary>
        /// Import an assembly, and its settings.
        /// </summary>
        /// <param name="assemblyPath">The path to the file in which the Assembly is located</param>
        private SR.Assembly ImportAssembly(string assemblyPath)
        {
            return SR.Assembly.LoadFrom(assemblyPath);

            //byte[] assemblyBytes = File.ReadAllBytes(assemblyPath);
            //string pdbPath, mdbPath;

            //if (File.Exists((pdbPath = Path.ChangeExtension(assemblyPath, "pdb"))))
            //    return SR.Assembly.Load(assemblyBytes, File.ReadAllBytes(pdbPath));
            //else if (File.Exists((mdbPath = Path.ChangeExtension(assemblyPath, "mdb"))))
            //    return SR.Assembly.Load(assemblyBytes, File.ReadAllBytes(mdbPath));
            //else
            //    return SR.Assembly.Load(assemblyBytes);
        }
        
        /// <summary>
        /// Scan an <see cref="AssemblyDefinition"/>'s custom attributes
        /// for a <see cref="InsiderSettingAttribute"/>.
        /// </summary>
        private void ImportAssemblySettings(AssemblyDefinition assembly, bool removeAttr = false)
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

                    if (removeAttr && cleanUp)
                        assembly.CustomAttributes.RemoveAt(i--);
                }
                else if (Extends<InsiderSettingAttribute>(attr.AttributeType.AsTypeDefinition()))
                {
                    foreach (var field in attr.Fields)
                        Settings[typeDef.Namespace + '.' + field.Name] = field.Argument.GetValue();
                    foreach (var prop in attr.Properties)
                        Settings[typeDef.Namespace + '.' + prop.Name] = prop.Argument.GetValue();

                    if (removeAttr && cleanUp)
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
        private void ImportDefaultSettings(ModuleDefinition module)
        {
            bool cleanUp = ShouldCleanUp;

            foreach (TypeDefinition type in module.Types)
            {
                if (Extends<InsiderSettingAttribute>(type))
                {
                    foreach (IMemberDefinition member in type.Fields.OfType<IMemberDefinition>().Concat(type.Properties))
                    {
                        CustomAttribute attr = member.GetAttribute<DefaultSettingAttribute>();
                        if (attr == null)
                            continue;

                        string name = type.Namespace + '.' + member.Name;
                        if (!Settings.ContainsKey(name))
                            Settings[name] = attr.ConstructorArguments[0].GetValue();

                        if (cleanUp)
                            member.CustomAttributes.Remove(attr);
                    }
                }
            }
        }

        /// <summary>
        /// Set the <see cref="Weave.Assemblies"/>, <see cref="Weave.CurrentAssembly"/>
        /// and <see cref="Weave.CurrentAssemblyDef"/> properties of a
        /// given assembly.
        /// </summary>
        //private void SetAssemblyWeave(AssemblyDefinition assemblyDef, SR.Assembly assembly)
        //{
        //    Type weaveType = assembly.GetType(nameof(Weave));

        //    if (weaveType != null)
        //    {
        //        weaveType.GetProperty(nameof(Weave.CurrentAssembly)).SetValue(null, Assembly);
        //        weaveType.GetProperty(nameof(Weave.CurrentAssemblyDef)).SetValue(null, Module.Assembly);
        //        weaveType.GetField(nameof(Weave.Assemblies)).SetValue(null, Assemblies);
        //    }
        //}

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
