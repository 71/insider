using System;
using System.Linq;
using System.Reflection;
using Mono.Cecil;

namespace Insider
{
    public static partial class Weave
    {
        /// <summary>
        /// Returns whether or not <paramref name="typeRef"/> and <paramref name="type"/>
        /// are equal.
        /// </summary>
        /// <param name="acceptDerivedTypes">
        /// If <code>true</code>, this method will be called recursively on <code>typeRef.BaseType</code>.
        /// </param>
        public static bool Is(this TypeReference typeRef, Type type, bool acceptDerivedTypes = true)
        {
            TypeDefinition def;
            return typeRef.FullName == type.FullName ||
                (acceptDerivedTypes && (def = typeRef.AsTypeDefinition())?.BaseType != null && def.BaseType.Is(type, acceptDerivedTypes));
        }

        /// <summary>
        /// Returns whether or not <paramref name="typeRef"/> and <typeparamref name="T"/>
        /// are equal.
        /// </summary>
        /// <param name="acceptDerivedTypes">
        /// If <code>true</code>, this method will be called recursively on <code>typeRef.BaseType</code>.
        /// </param>
        public static bool Is<T>(this TypeReference typeRef, bool acceptDerivedTypes = true)
            => Is(typeRef, typeof(T), acceptDerivedTypes);

        /// <summary>
        /// Returns whether or not <paramref name="typeRef"/> and <paramref name="type"/>
        /// are equal.
        /// </summary>
        /// <param name="acceptDerivedTypes">
        /// If <code>true</code>, this method will be called recursively on <code>typeRef.BaseType</code>.
        /// </param>
        public static bool Is(this Type type, TypeReference typeRef, bool acceptDerivedTypes = true)
            => Is(typeRef, type, acceptDerivedTypes);


        /// <summary>
        /// Returns whether or not <paramref name="methodRef"/> and <paramref name="method"/>
        /// are equal.
        /// </summary>
        public static bool Is(this MethodReference methodRef, MethodInfo method)
            => methodRef.Name == method.Name && methodRef.DeclaringType.Is(method.DeclaringType)
            && methodRef.Parameters.Select(x => x.ParameterType.AsType()).SequenceEqual(method.GetParameters().Select(x => x.ParameterType));

        /// <summary>
        /// Returns whether or not <paramref name="propRef"/> and <paramref name="prop"/>
        /// are equal.
        /// </summary>
        public static bool Is(this PropertyReference propRef, PropertyInfo prop)
            => propRef.Name == prop.Name && propRef.DeclaringType.Is(prop.DeclaringType);

        /// <summary>
        /// Returns whether or not <paramref name="fieldRef"/> and <paramref name="field"/>
        /// are equal.
        /// </summary>
        public static bool Is(this FieldReference fieldRef, FieldInfo field)
            => fieldRef.Name == field.Name && fieldRef.DeclaringType.Is(field.DeclaringType);
    }
}
