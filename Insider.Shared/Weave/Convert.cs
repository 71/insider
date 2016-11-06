using System;
using System.Linq;
using System.Reflection;
using Mono.Cecil;

namespace Insider
{
    public static partial class Weave
    {
        /// <summary>
        /// Convert <see cref="TypeReference.FullName"/> to <see cref="Type.FullName"/>
        /// and return the converted name.
        /// </summary>
        public static string GetReflectionName(this TypeReference type)
        {
            if (type.IsGenericInstance)
            {
                var genericInstance = (GenericInstanceType)type;
                return String.Format("{0}.{1}[{2}]", genericInstance.Namespace, type.Name, String.Join(",", genericInstance.GenericArguments.Select(p => p.GetReflectionName()).ToArray()));
            }
            return type.FullName;
        }

        /// <summary>
        /// Convert <see cref="Type.FullName"/> to <see cref="TypeReference.FullName"/>
        /// and return the converted name.
        /// </summary>
        public static string GetReferenceName(this Type type)
        {
            if (type.GenericTypeArguments.Length > 0)
                return String.Format("{0}.{1}<{2}>", type.Namespace, type.Name, String.Join(",", type.GenericTypeArguments.Select(x => x.GetReferenceName()).ToArray()));
            return type.FullName;
        }


        /// <summary>
        /// Make a <see cref="GenericInstanceMethod"/>, given its <see cref="MethodReference"/>
        /// and its generic arguments.
        /// </summary>
        public static GenericInstanceMethod MakeGenericMethod(this MethodReference method, params TypeReference[] genericArguments)
        {
            var result = new GenericInstanceMethod(method);
            foreach (var argument in genericArguments)
                result.GenericArguments.Add(argument);
            return result;
        }

        /// <summary>
        /// Make a <see cref="GenericInstanceType"/>, given its <see cref="TypeReference"/>
        /// and its generic arguments.
        /// </summary>
        public static GenericInstanceType MakeGenericType(this TypeReference type, params TypeReference[] genericArguments)
        {
            var result = new GenericInstanceType(type);
            foreach (var argument in genericArguments)
                result.GenericArguments.Add(argument);
            return result;
        }


        /// <summary>
        /// Return the <see cref="MethodDefinition"/> of a given <see cref="MethodInfo"/>.
        /// </summary>
        public static MethodDefinition AsMethodDefinition(this MethodInfo method)
            => method.DeclaringType.AsTypeDefinition()?.FindMethod(method.Name, method.GetParameters().Select(x => x.ParameterType).ToArray());

        /// <summary>
        /// Return the <see cref="MethodInfo"/> of a given <see cref="MethodDefinition"/>.
        /// </summary>
        public static MethodInfo AsMethodInfo(this MethodReference method)
            => method.DeclaringType.AsType()?.GetRuntimeMethod(method.Name, method.Parameters.Select(x => x.ParameterType.AsType()).ToArray());


        /// <summary>
        /// Return the <see cref="FieldDefinition"/> of a given <see cref="FieldInfo"/>.
        /// </summary>
        public static FieldDefinition AsFieldDefinition(this FieldInfo field)
            => field.DeclaringType.AsTypeDefinition()?.FindField(field.Name);

        /// <summary>
        /// Return the <see cref="FieldInfo"/> of a given <see cref="FieldDefinition"/>.
        /// </summary>
        public static FieldInfo AsFieldInfo(this FieldDefinition field)
            => field.DeclaringType.AsType()?.GetRuntimeField(field.Name);


        /// <summary>
        /// Return the <see cref="PropertyDefinition"/> of a given <see cref="PropertyInfo"/>.
        /// </summary>
        public static PropertyDefinition AsPropertyDefinition(this PropertyInfo prop)
            => prop.DeclaringType.AsTypeDefinition()?.FindProperty(prop.Name);

        /// <summary>
        /// Return the <see cref="PropertyInfo"/> of a given <see cref="PropertyDefinition"/>.
        /// </summary>
        public static PropertyInfo AsPropertyInfo(this PropertyDefinition prop)
            => prop.DeclaringType.AsType()?.GetRuntimeProperty(prop.Name);


        /// <summary>
        /// Return the <see cref="EventDefinition"/> of a given <see cref="EventInfo"/>.
        /// </summary>
        public static EventDefinition AsEventDefinition(this EventInfo @event)
            => @event.DeclaringType.AsTypeDefinition()?.FindEvent(@event.Name);

        /// <summary>
        /// Return the <see cref="EventInfo"/> of a given <see cref="EventDefinition"/>.
        /// </summary>
        public static EventInfo AsEventInfo(this EventDefinition @event)
            => @event.DeclaringType.AsType()?.GetRuntimeEvent(@event.Name);


        /// <summary>
        /// Return the matching <see cref="AssemblyDefinition"/> of a
        /// given <see cref="Assembly"/>.
        /// </summary>
        public static AssemblyDefinition AsAssemblyDefinition(this Assembly assembly)
        {
            if (assembly == CurrentAssembly)
                return CurrentAssemblyDef;

            string name = assembly.GetName().Name;
            Tuple<Assembly, AssemblyDefinition> result;
            if (Assemblies.TryGetValue(name, out result))
                return result.Item2;
            return null;
        }

        /// <summary>
        /// Return the matching <see cref="Assembly"/> of a
        /// given <see cref="AssemblyDefinition"/>.
        /// </summary>
        public static Assembly AsAssemblyInfo(this AssemblyDefinition assembly)
        {
            if (assembly == CurrentAssemblyDef)
                return CurrentAssembly;
            
            Tuple<Assembly, AssemblyDefinition> result;
            if (Assemblies.TryGetValue(assembly.Name.Name, out result))
                return result.Item1;
            return null;
        }

        /// <summary>
        /// Initialize an attribute of type <typeparamref name="T"/>
        /// given its compiled <see cref="Mono.Cecil.CustomAttribute"/> representation.
        /// </summary>
        public static T Construct<T>(this CustomAttribute customAttr) where T : Attribute
        {
            object attr = customAttr.Constructor.AsMethodInfo().Invoke(null, customAttr.ConstructorArguments.Select(GetValue).ToArray());
            Type attrType = attr.GetType();

            foreach (var field in customAttr.Fields)
                attrType.GetRuntimeField(field.Name).SetValue(attr, field.Argument.GetValue());

            foreach (var prop in customAttr.Properties)
                attrType.GetRuntimeProperty(prop.Name).SetValue(attr, prop.Argument.GetValue());

            return (T)attr;
        }
    }
}
