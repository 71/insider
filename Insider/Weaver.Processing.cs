using System;
using System.IO;
using System.Linq;
using Mono.Cecil;
using R = System.Reflection;

namespace Insider
{
    public sealed partial class Weaver : IDisposable
    {
        /// <summary>
        /// Process every definition in the module.
        /// </summary>
        public void Process()
        {
            try
            {
                ProcessInternal();                
                Module.Write(TargetPath);
            }
            catch (Exception e)
            {
                throw new WeavingException("Cannot access target file. Make sure the intermediate directory is not in read-only mode!", e);
            }
        }

        /// <summary>
        /// Process every definition in the module.
        /// </summary>
        private void ProcessInternal()
        {
            bool cleanUp = ShouldCleanUp;

            // Process assembly
            for (int i = 0; i < Module.Assembly.CustomAttributes.Count; i++)
                if (ProcessAny<IAssemblyWeaver>(Module.Assembly.CustomAttributes[i], Module.Assembly) && cleanUp)
                    i--;

            // Process types
            foreach (TypeDefinition typeDef in Module.Types)
            {
                // Process fields
                foreach (FieldDefinition fieldDef in typeDef.Fields)
                {
                    for (int i = 0; i < fieldDef.CustomAttributes.Count; i++)
                        if (ProcessAny<IFieldWeaver>(fieldDef.CustomAttributes[i], fieldDef) && cleanUp)
                            i--;
                }

                // Process properties
                foreach (PropertyDefinition propDef in typeDef.Properties)
                {
                    for (int i = 0; i < propDef.CustomAttributes.Count; i++)
                        if (ProcessAny<IPropertyWeaver>(propDef.CustomAttributes[i], propDef) && cleanUp)
                            i--;
                }

                // Process events
                foreach (EventDefinition eventDef in typeDef.Events)
                {
                    for (int i = 0; i < eventDef.CustomAttributes.Count; i++)
                        if (ProcessAny<IEventWeaver>(eventDef.CustomAttributes[i], eventDef) && cleanUp)
                            i--;
                }

                // Process methods
                foreach (MethodDefinition methodDef in typeDef.Methods)
                {
                    // Process parameters
                    foreach (ParameterDefinition paramDef in methodDef.Parameters)
                    {
                        for (int i = 0; i < paramDef.CustomAttributes.Count; i++)
                            if (ProcessAny<IParameterWeaver>(paramDef.CustomAttributes[i], paramDef, methodDef) && cleanUp)
                                i--;
                    }

                    for (int i = 0; i < methodDef.CustomAttributes.Count; i++)
                        if (ProcessAny<IMethodWeaver>(methodDef.CustomAttributes[i], methodDef) && cleanUp)
                            i--;
                }

                for (int i = 0; i < typeDef.CustomAttributes.Count; i++)
                    if (ProcessAny<ITypeWeaver>(typeDef.CustomAttributes[i], typeDef) && cleanUp)
                        i--;
            }


            if (cleanUp)
            {
                // Remove attribute definition
                for (int i = 0; i < Module.Types.Count; i++)
                {
                    if (Extends<WeaverAttribute>(Module.Types[i]))
                        Module.Types.RemoveAt(i--);
                }

                // Remove reference to Insider, Mono.Cecil
                for (int i = 0; i < Module.AssemblyReferences.Count; i++)
                {
                    AssemblyNameReference assembly = Module.AssemblyReferences[i];
                    if (assembly.Name.StartsWith(ASSEMBLY_NAME) || assembly.Name.StartsWith("Mono.Cecil"))
                        Module.AssemblyReferences.RemoveAt(i--);
                    else if (Assemblies.ContainsKey(assembly.Name))
                    {
                        AssemblyDefinition def = Assemblies[assembly.Name].Item2;
                        if (def.MainModule.AssemblyReferences.Any(x => x.Name.StartsWith(ASSEMBLY_NAME)))
                            Module.AssemblyReferences.RemoveAt(i--);
                    }
                }
            }
        }

        /// <summary>
        /// Process a single definition.
        /// </summary>
        /// <returns><code>true</code> if the attribute was a weaver ; <code>false</code> otherwise.</returns>
        private bool ProcessAny<TWeaver>(CustomAttribute attr, params object[] defs) where TWeaver : IWeaver
        {
            TypeDefinition attrTypeDef = attr.AttributeType.AsTypeDefinition();

            // Make sure it's a weaver
            if (!Extends<WeaverAttribute>(attrTypeDef))
                return false;
            if (!Extends<TWeaver>(attrTypeDef))
                return false;

            // Create the attribute
            Type attrType = attr.AttributeType.AsType();
            R.PropertyInfo logProp = attrType.GetProperty(nameof(WeaverAttribute.LogInternal), R.BindingFlags.NonPublic | R.BindingFlags.Instance);
            R.PropertyInfo setProp = attrType.GetProperty(nameof(WeaverAttribute.Settings), R.BindingFlags.NonPublic | R.BindingFlags.Instance);
            
            R.ConstructorInfo weaverCtor = attrType.GetConstructor(attr.ConstructorArguments.Select(x =>  x.Type.AsType()).ToArray());
            object weaver = weaverCtor.Invoke(attr.ConstructorArguments.Select(Weave.GetValue).ToArray());

            // Add ability to log messages, and set settings
            if (LogMessageDelegate == null)
                LogMessageDelegate = Delegate.CreateDelegate(logProp.PropertyType, this, nameof(Weaver.LogMessage));

            logProp.SetValue(weaver, LogMessageDelegate);
            setProp.SetValue(weaver, Settings);

            // Invoke Weaver.Apply();
            try
            {
                // TODO: Weavers -> Interfaces, to allow a single attribute to be applied on different declarations.
                if ((bool)Settings[$"{ASSEMBLY_NAME}.{nameof(InsiderAttribute.Debug)}"])
                    System.Diagnostics.Debugger.Launch();

                LogMessage(weaver, $"Processing {(defs[0] as IMemberDefinition).FullName}...", MessageImportance.Debug);

                R.MethodInfo method = attrType.GetMethod(nameof(IAssemblyWeaver.Apply), defs.Select(x => x.GetType()).ToArray());
                method.Invoke(weaver, defs);
            }
            catch (Exception e)
            {
                throw new WeavingException(weaver, e.Message, MessageImportance.Error);
            }

            // Clear attribute
            if (ShouldCleanUp)
            {
                foreach (IMemberDefinition def in defs.OfType<IMemberDefinition>())
                    def.CustomAttributes.Remove(attr);
            }

            return true;
        }
    }
}
