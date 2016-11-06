using System;
using System.Linq.Expressions;
using System.Reflection;
using Mono.Cecil.Cil;

namespace Insider.Extensions
{
    public static partial class IL
    {
        #region Load
        /// <summary>
        /// Push <code>null</code> into the stack.
        /// </summary>
        public static Instruction Load()
            => Instruction.Create(OpCodes.Ldnull);

        /// <summary>
        /// Push a <see cref="string"/> into the stack.
        /// </summary>
        public static Instruction Load(string arg)
            => Instruction.Create(OpCodes.Ldstr, arg);

        /// <summary>
        /// Push a <see cref="double"/> into the stack.
        /// </summary>
        public static Instruction Load(double arg)
            => Instruction.Create(OpCodes.Ldc_R8, arg);

        /// <summary>
        /// Push a <see cref="float"/> into the stack.
        /// </summary>
        public static Instruction Load(float arg)
            => Instruction.Create(OpCodes.Ldc_R4, arg);

        /// <summary>
        /// Push a <see cref="bool"/> into the stack.
        /// </summary>
        public static Instruction Load(bool arg)
            => Instruction.Create(arg ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);

        /// <summary>
        /// Push a <see cref="long"/> into the stack.
        /// </summary>
        public static Instruction Load(long arg)
            => Instruction.Create(OpCodes.Ldc_I8, arg);

        /// <summary>
        /// Push an <see cref="int"/> into the stack.
        /// </summary>
        public static Instruction Load(int arg)
        {
            switch (arg)
            {
                case 0:
                    return Instruction.Create(OpCodes.Ldc_I4_0);
                case 1:
                    return Instruction.Create(OpCodes.Ldc_I4_1);
                case 2:
                    return Instruction.Create(OpCodes.Ldc_I4_2);
                case 3:
                    return Instruction.Create(OpCodes.Ldc_I4_3);
                case 4:
                    return Instruction.Create(OpCodes.Ldc_I4_4);
                case 5:
                    return Instruction.Create(OpCodes.Ldc_I4_5);
                case 6:
                    return Instruction.Create(OpCodes.Ldc_I4_6);
                case 7:
                    return Instruction.Create(OpCodes.Ldc_I4_7);
                case 8:
                    return Instruction.Create(OpCodes.Ldc_I4_8);
                case -1:
                    return Instruction.Create(OpCodes.Ldc_I4_M1);
                default:
                    return Instruction.Create(OpCodes.Ldc_I4, arg);
            }
        }

        /// <summary>
        /// Push the nth method argument into the stack.
        /// </summary>
        public static Instruction LoadArg(int nthArg)
        {
            switch (nthArg)
            {
                case 0:
                    return Instruction.Create(OpCodes.Ldarg_0);
                case 1:
                    return Instruction.Create(OpCodes.Ldarg_1);
                case 2:
                    return Instruction.Create(OpCodes.Ldarg_2);
                case 3:
                    return Instruction.Create(OpCodes.Ldarg_3);
            }

            if (nthArg <= byte.MaxValue)
                return Instruction.Create(OpCodes.Ldarg_S, (byte)nthArg);
            else
                return Instruction.Create(OpCodes.Ldarg, nthArg);
        }

        /// <summary>
        /// Push the nth local variable into the stack.
        /// </summary>
        public static Instruction LoadVar(int nthLocalVar)
        {
            switch (nthLocalVar)
            {
                case 0:
                    return Instruction.Create(OpCodes.Ldloc_0);
                case 1:
                    return Instruction.Create(OpCodes.Ldloc_1);
                case 2:
                    return Instruction.Create(OpCodes.Ldloc_2);
                case 3:
                    return Instruction.Create(OpCodes.Ldloc_3);
            }

            if (nthLocalVar <= byte.MaxValue)
                return Instruction.Create(OpCodes.Ldloc_S, (byte)nthLocalVar);
            else
                return Instruction.Create(OpCodes.Ldloc, nthLocalVar);
        }

        /// <summary>
        /// Push the value of a field or property into the stack.
        /// </summary>
        public static Instruction Load<T, TMember>(Expression<Func<T, TMember>> expr)
        {
            MemberExpression ex = expr as MemberExpression;
            if (ex == null)
                throw new ArgumentException("expr must be a MemberExpression");

            if (ex.Member is FieldInfo)
            {
                FieldInfo field = (FieldInfo)ex.Member;
                return Instruction.Create(field.IsStatic ? OpCodes.Ldsfld : OpCodes.Ldfld, ((FieldInfo)ex.Member).AsFieldDefinition());
            }
            else if (ex.Member is PropertyInfo)
            {
                PropertyInfo prop = (PropertyInfo)ex.Member;
                FieldInfo backingField = prop.DeclaringType.GetRuntimeField($"<{ex.Member.Name}>k__BackingField");

                if (backingField != null)
                    return Instruction.Create(backingField.IsStatic ? OpCodes.Ldsfld : OpCodes.Ldfld, backingField.AsFieldDefinition());
                else if (prop.GetMethod != null)
                    return Call(prop.GetMethod);
                else
                    throw new ArgumentException("expr must have a getter");
            }
            else
            {
                throw new ArgumentException("expr must reference a field or property");
            }
        }
        #endregion

        #region Call
        public static Instruction Call(Type type, string name, params Type[] paramTypes)
            => Call(type.AsTypeDefinition().FindMethod(name, paramTypes));
        public static Instruction Call(Type type, string name)
            => Call(type.AsTypeDefinition().FindMethod(name));
        public static Instruction Call<T>(string name, params Type[] paramTypes)
            => Call(typeof(T), name, paramTypes);
        public static Instruction Call<T>(string name)
            => Call(typeof(T), name);
        public static Instruction Call(MethodInfo method)
            => method.IsStatic ? Call(method.AsMethodDefinition()) : Callvirt(method.AsMethodDefinition());
        #endregion
    }
}
