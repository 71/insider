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

                // For some reason, an error is thrown when I try to write
                // the module to [Module.FileName], stating that a process
                // is using it. However, I am able to remove it, which proves
                // the error wrong. Whatever works I guess.
                
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
            // Process assembly
            foreach (CustomAttribute attr in Module.Assembly.CustomAttributes)
                ProcessAny<AssemblyWeaverAttribute>(attr, Module.Assembly);

            // Process types
            foreach (TypeDefinition typeDef in Module.Types)
            {
                // Process fields
                foreach (FieldDefinition fieldDef in typeDef.Fields)
                {
                    foreach (CustomAttribute attr in fieldDef.CustomAttributes)
                        ProcessAny<FieldWeaverAttribute>(attr, fieldDef);
                }

                // Process properties
                foreach (PropertyDefinition propDef in typeDef.Properties)
                {
                    foreach (CustomAttribute attr in propDef.CustomAttributes)
                        ProcessAny<PropertyWeaverAttribute>(attr, propDef);
                }

                // Process events
                foreach (EventDefinition eventDef in typeDef.Events)
                {
                    foreach (CustomAttribute attr in eventDef.CustomAttributes)
                        ProcessAny<EventWeaverAttribute>(attr, eventDef);
                }

                // Process methods
                foreach (MethodDefinition methodDef in typeDef.Methods)
                {
                    // Process parameters
                    foreach (ParameterDefinition paramDef in methodDef.Parameters)
                    {
                        foreach (CustomAttribute attr in paramDef.CustomAttributes)
                            ProcessAny<ParameterWeaverAttribute>(attr, paramDef, methodDef);
                    }

                    for (int i = 0; i < methodDef.CustomAttributes.Count; i++)
                        ProcessAny<MethodWeaverAttribute>(methodDef.CustomAttributes[i], methodDef);
                }

                foreach (CustomAttribute attr in typeDef.CustomAttributes)
                    ProcessAny<TypeWeaverAttribute>(attr, typeDef);
            }

            if (Settings.ContainsKey("Insider.CleanUp") && (bool)Settings["Insider.CleanUp"])
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
                    if (assembly.Name.StartsWith("Insider") || assembly.Name.StartsWith("Mono.Cecil"))
                        Module.AssemblyReferences.RemoveAt(i--);
                }
            }
        }

        /// <summary>
        /// Process a single definition.
        /// </summary>
        private void ProcessAny<TWeaver>(CustomAttribute attr, params object[] defs) where TWeaver : WeaverAttribute
        {
            // Make sure it's a weaver
            if (!Extends<TWeaver>(GetTypeDefinition(attr.AttributeType)))
                return;

            // Create the attribute
            Type attrType = attr.AttributeType.AsType();
            R.PropertyInfo logProp = attrType.GetProperty(nameof(WeaverAttribute.LogInternal), R.BindingFlags.NonPublic | R.BindingFlags.Instance);
            R.PropertyInfo setProp = attrType.GetProperty(nameof(WeaverAttribute.Settings), R.BindingFlags.NonPublic | R.BindingFlags.Instance);
            //object weaver = Activator.CreateInstance(attrType, attr.ConstructorArguments.Select(x => x.Value).ToArray());
            object weaver = attrType
                .GetConstructor(attr.ConstructorArguments.Select(x => x.Type.AsType()).ToArray())
                .Invoke(attr.ConstructorArguments.Select(x => x.Value).ToArray());

            // Add ability to log messages, and set settings
            if (LogMessageDelegate == null)
                LogMessageDelegate = Delegate.CreateDelegate(logProp.PropertyType, this, nameof(Weaver.LogMessage));

            logProp.SetValue(weaver, LogMessageDelegate);
            setProp.SetValue(weaver, Settings);

            // Invoke Weaver.Apply();
            try
            {
                if ((bool)Settings["Insider." + nameof(InsiderAttribute.Debug)])
                    System.Diagnostics.Debugger.Launch();

                LogMessage(weaver, $"Processing {(defs[0] as IMemberDefinition).FullName}...", MessageImportance.Debug);

                R.MethodInfo method = attrType.GetMethod("Apply", defs.Select(x => x.GetType()).ToArray());
                method.Invoke(weaver, defs);
            }
            catch (Exception e)
            {
                throw new WeavingException(weaver, e.Message, MessageImportance.Error);
            }

            // Clear attribute
            foreach (IMemberDefinition def in defs.OfType<IMemberDefinition>())
                def.CustomAttributes.Remove(attr);
        }
    }
}
