using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Mono.Cecil;

namespace Insider
{
    public static partial class Weave
    {
        #region Custom Attributes
        /// <summary>
        /// Returns all <see cref="CustomAttribute"/>s that match <typeparamref name="TAttr"/>.
        /// </summary>
        public static IEnumerable<CustomAttribute> GetAttributes<TAttr>(this IMemberDefinition def) where TAttr : Attribute
            => def.CustomAttributes.Where(x => x.AttributeType.Is<TAttr>(true));

        /// <summary>
        /// Returns the first <see cref="CustomAttribute"/>s that matches <typeparamref name="TAttr"/>,
        /// or <code>null</code>.
        /// </summary>
        public static CustomAttribute GetAttribute<TAttr>(this IMemberDefinition def) where TAttr : Attribute
            => GetAttributes<TAttr>(def).FirstOrDefault();

        /// <summary>
        /// Returns all <see cref="CustomAttribute"/>s that match <typeparamref name="TAttr"/>.
        /// </summary>
        public static IEnumerable<CustomAttribute> GetAttributes<TAttr>(this AssemblyDefinition def) where TAttr : Attribute
            => def.CustomAttributes.Where(x => x.AttributeType.Is<TAttr>(true));

        /// <summary>
        /// Returns the first <see cref="CustomAttribute"/>s that matches <typeparamref name="TAttr"/>,
        /// or <code>null</code>.
        /// </summary>
        public static CustomAttribute GetAttribute<TAttr>(this AssemblyDefinition def) where TAttr : Attribute
            => GetAttributes<TAttr>(def).FirstOrDefault();

        /// <summary>
        /// Returns all <see cref="CustomAttribute"/>s that match <typeparamref name="TAttr"/>.
        /// </summary>
        public static IEnumerable<CustomAttribute> GetAttributes<TAttr>(this ParameterDefinition def) where TAttr : Attribute
            => def.CustomAttributes.Where(x => x.AttributeType.Is<TAttr>(true));

        /// <summary>
        /// Returns the first <see cref="CustomAttribute"/>s that matches <typeparamref name="TAttr"/>,
        /// or <code>null</code>.
        /// </summary>
        public static CustomAttribute GetAttribute<TAttr>(this ParameterDefinition def) where TAttr : Attribute
            => GetAttributes<TAttr>(def).FirstOrDefault();
        #endregion

        /// <summary>
        /// Find the first parameter-less method whose <see cref="MethodDefinition.DeclaringType"/> is
        /// <paramref name="type"/>, and <see cref="MethodDefinition.Name"/> is <paramref name="name"/>.
        /// </summary>
        public static MethodDefinition FindMethod(this TypeDefinition type, string name)
            => type.Methods.FirstOrDefault(x => x.Name == name && x.Parameters.Count == 0);

        /// <summary>
        /// Find the first method whose <see cref="MethodDefinition.DeclaringType"/> is
        /// <paramref name="type"/>, <see cref="MethodDefinition.Name"/> is <paramref name="name"/>,
        /// and <see cref="MethodReference.Parameters"/> is equivalent to <paramref name="paramTypes"/>.
        /// </summary>
        public static MethodDefinition FindMethod(this TypeDefinition type, string name, params Type[] paramTypes)
            => type.Methods.FirstOrDefault(x => x.Name == name
                && x.Parameters.Select(y => y.ParameterType.FullName).SequenceEqual(paramTypes.Select(y => y.GetReferenceName())));

        /// <summary>
        /// Find the first method whose <see cref="MethodDefinition.DeclaringType"/> is
        /// <paramref name="type"/>, <see cref="MethodDefinition.Name"/> is <paramref name="name"/>,
        /// and <see cref="MethodReference.Parameters"/> is equal to <paramref name="paramTypes"/>.
        /// </summary>
        public static MethodDefinition FindMethod(this TypeDefinition type, string name, params TypeDefinition[] paramTypes)
            => type.Methods.FirstOrDefault(x => x.Name == name && x.Parameters.Select(y => y.ParameterType).SequenceEqual(paramTypes));


        /// <summary>
        /// Find the first field of <paramref name="type"/>
        /// whose <see cref="MemberReference.Name"/> is <paramref name="name"/>.
        /// </summary>
        public static FieldDefinition FindField(this TypeDefinition type, string name)
            => type.Fields.FirstOrDefault(x => x.Name == name);

        /// <summary>
        /// Find the first field of <paramref name="type"/>
        /// that matches a given field of <typeparamref name="T"/>.
        /// </summary>
        public static FieldDefinition FindField<T, TField>(this TypeDefinition type, Expression<Func<T, TField>> expr)
        {
            MemberExpression dp = expr.Body as MemberExpression;
            if (!(dp.Member is FieldInfo))
                throw new ArgumentException($"{nameof(expr)} must reference a field.");

            return type.Fields.FirstOrDefault(x => x.Equals((FieldInfo)dp.Member));
        }


        /// <summary>
        /// Find the first property of <paramref name="type"/>
        /// whose <see cref="MemberReference.Name"/> is <paramref name="name"/>.
        /// </summary>
        public static PropertyDefinition FindProperty(this TypeDefinition type, string name)
            => type.Properties.FirstOrDefault(x => x.Name == name);

        /// <summary>
        /// Find the first property of <paramref name="type"/>
        /// that matches a given property of <typeparamref name="T"/>.
        /// </summary>
        public static PropertyDefinition FindProperty<T, TProp>(this TypeDefinition type, Expression<Func<T, TProp>> expr)
        {
            MemberExpression dp = expr.Body as MemberExpression;
            if (!(dp.Member is PropertyInfo))
                throw new ArgumentException($"{nameof(expr)} must reference a property.");

            return type.FindProperty(dp.Member.Name);
        }


        /// <summary>
        /// Find the first event of <paramref name="type"/>
        /// whose <see cref="MemberReference.Name"/> is <paramref name="name"/>.
        /// </summary>
        public static EventDefinition FindEvent(this TypeDefinition type, string name)
            => type.Events.FirstOrDefault(x => x.Name == name);

        /// <summary>
        /// Find the first event of <paramref name="type"/>
        /// that matches a given event of <typeparamref name="T"/>.
        /// </summary>
        public static EventDefinition FindEvent<T, TEvent>(this TypeDefinition type, Expression<Func<T, TEvent>> expr)
        {
            MemberExpression dp = expr.Body as MemberExpression;
            if (!(dp.Member is EventInfo))
                throw new ArgumentException($"{nameof(expr)} must reference an event.");

            return type.FindEvent(dp.Member.Name);
        }
    }
}
