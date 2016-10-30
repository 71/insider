using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using R = System.Reflection;

namespace Insider
{
    /// <summary>
    /// Class used to weave modules.
    /// </summary>
    public sealed partial class Weaver : IDisposable
    {
        /// <summary>
        /// Module being woven.
        /// </summary>
        public readonly ModuleDefinition Module;

        /// <summary>
        /// Assembly being woven.
        /// </summary>
        public readonly R.Assembly Assembly;

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
        /// (<see cref="R.AssemblyName.Name"/>).
        /// </summary>
        private readonly Dictionary<string, Tuple<R.Assembly, AssemblyDefinition>> Assemblies;

        /// <summary>
        /// <see cref="Delegate"/> that calls <see cref="LogMessage(string, MessageImportance)"/>.
        /// </summary>
        private Delegate LogMessageDelegate;

        private readonly AppDomain ProcessDomain;

        /// <summary>
        /// Initialize a new <see cref="Weaver"/>, given the path to the
        /// assembly it will weave.
        /// </summary>
        /// <param name="filepath">Absolute path of the assembly to weave</param>
        /// <param name="referencedFiles">Absolute paths of the files referenced by the assembly to weave</param>
        public Weaver(string filepath, string targetpath, params string[] referencedFiles)
        {
            ProcessDomain = AppDomain.CreateDomain("Insider weaving domain");
            ProcessDomain.ExecuteAssembly()
            // Since it is not possible to both unload an Assembly
            // and load its type, it has to be copied before being read.
            string assemblyPath = filepath + ".weaving";
            File.Copy(filepath, assemblyPath, true);

            TargetPath = targetpath;

            // Resolve assembly, module, and initialize settings
            Module = ModuleDefinition.ReadModule(filepath, new ReaderParameters { InMemory = true });
            Assembly = R.Assembly.LoadFrom(assemblyPath);

            Assemblies = new Dictionary<string, Tuple<R.Assembly, AssemblyDefinition>>();
            Settings = new Dictionary<string, object>();

            // Set local Weave properties
            Weave.CurrentAssembly = Assembly;
            Weave.CurrentAssemblyDef = Module.Assembly;
            Weave.Assemblies = Assemblies;

            // Import default settings
            // Retrieve references
            foreach (string referencedFile in referencedFiles)
            {
                // After hours of debugging, I know why MethodDefinition can no longer
                // be cast from one assembly to the other!!
                // Looks like LoadFrom() "breaks" the already loaded types.
                // <3 http://stackoverflow.com/a/8059052/5117446 <3
                if (referencedFile.EndsWith("Mono.Cecil.dll"))
                    continue;

                var assembly = R.Assembly.LoadFrom(referencedFile);
                var assemblyDef = AssemblyDefinition.ReadAssembly(referencedFile);

                ImportDefaultSettings(assemblyDef.MainModule);
                ImportAssemblySettings(assemblyDef);
                Assemblies.Add(assemblyDef.Name.Name, Tuple.Create(assembly, assemblyDef));
            }

            ImportDefaultSettings(Module);
            ImportAssemblySettings(Module.Assembly);
        }

        /// <summary>
        /// Scan an <see cref="AssemblyDefinition"/>'s custom attributes
        /// for a <see cref="InsiderSettingAttribute"/>.
        /// </summary>
        private void ImportAssemblySettings(AssemblyDefinition assembly)
        {
            for (int i = 0; i < assembly.CustomAttributes.Count; i++)
            {
                CustomAttribute attr = assembly.CustomAttributes[i];
                TypeDefinition typeDef = GetTypeDefinition(attr.AttributeType);

                if (typeDef == null)
                    continue;

                if (typeDef.Is(typeof(SettingAttribute)))
                {
                    // For some reason some arguments are arguments themselves...
                    object value = attr.ConstructorArguments[1].Value;
                    while (value is CustomAttributeArgument)
                        value = ((CustomAttributeArgument)value).Value;

                    Settings.Add((string)attr.ConstructorArguments[0].Value, value);
                    assembly.CustomAttributes.RemoveAt(i);
                }
                else if (Extends<InsiderSettingAttribute>(GetTypeDefinition(attr.AttributeType)))
                {
                    foreach (var field in attr.Fields)
                        Settings.Add(typeDef.Namespace + '.' + field.Name, field.Argument.Value);
                    assembly.CustomAttributes.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Import default settings for every declared attribute that inherits
        /// <see cref="InsiderSettingAttribute"/>.
        /// </summary>
        private void ImportDefaultSettings(ModuleDefinition module)
        {
            foreach (TypeDefinition type in module.Types)
            {
                if (Extends<InsiderSettingAttribute>(type))
                {
                    foreach (IMemberDefinition member in type.Fields.OfType<IMemberDefinition>().Concat(type.Properties))
                    {
                        CustomAttribute attr = member.GetAttribute<DefaultSettingAttribute>();
                        if (attr == null)
                            continue;

                        object value = attr.ConstructorArguments[0].Value;
                        while (value is CustomAttributeArgument)
                            value = ((CustomAttributeArgument)value).Value;

                        Settings.Add(type.Namespace + '.' + member.Name, value);
                    }
                }
            }
        }

        /// <summary>
        /// Set the <see cref="Weave.Assemblies"/>, <see cref="Weave.CurrentAssembly"/>
        /// and <see cref="Weave.CurrentAssemblyDef"/> properties of a
        /// given assembly.
        /// </summary>
        private void SetAssemblyWeave(AssemblyDefinition assemblyDef, R.Assembly assembly)
        {
            Type weaveType = assembly.GetType(nameof(Weave));

            if (weaveType != null)
            {
                weaveType.GetProperty(nameof(Weave.CurrentAssembly)).SetValue(null, Assembly);
                weaveType.GetProperty(nameof(Weave.CurrentAssemblyDef)).SetValue(null, Module.Assembly);
                weaveType.GetField(nameof(Weave.Assemblies)).SetValue(null, Assemblies);
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
