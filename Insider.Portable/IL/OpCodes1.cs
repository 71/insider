using Mono.Cecil;
using Mono.Cecil.Cil;


namespace Insider
{
    /// <summary>
    /// Quick and easy access to IL methods.
    /// </summary>
    public static partial class IL
    {
        // Instructions found on https://en.wikipedia.org/wiki/List_of_CIL_instructions
        // License: https://creativecommons.org/licenses/by-sa/4.0/
        // Script used:
        //
        //  var table = document.querySelector('.wikitable');
        //  var names = table.querySelectorAll('td:nth-child(2)');
        //  var dscrs = table.querySelectorAll('td:nth-child(3)');
        //  var str = "";
        //  for (var i = 0; i < names.length; i++)
        //      str += '{ "' + names[i].innerText.trim() + '", "' + dscrs[i].innerText.trim() + '" },\n';
        //  return str;
        //
        // Then create a dictionary, classify by name, and I'm good.

        
        #region 
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Add"/>.
        /// <para>
        /// Add two values, returning a new value.
        /// </para>
        /// </summary>
        public static Instruction Add()
            => Instruction.Create(OpCodes.Add);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Add_Ovf"/>.
        /// <para>
        /// Add signed integer values with overflow check.
        /// </para>
        /// </summary>
        public static Instruction Add_Ovf()
            => Instruction.Create(OpCodes.Add_Ovf);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Add_Ovf_Un"/>.
        /// <para>
        /// Add unsigned integer values with overflow check.
        /// </para>
        /// </summary>
        public static Instruction Add_Ovf_Un()
            => Instruction.Create(OpCodes.Add_Ovf_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.And"/>.
        /// <para>
        /// Bitwise AND of two integral values, returns an integral value.
        /// </para>
        /// </summary>
        public static Instruction And()
            => Instruction.Create(OpCodes.And);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Arglist"/>.
        /// <para>
        /// Return argument list handle for the current method.
        /// </para>
        /// </summary>
        public static Instruction Arglist()
            => Instruction.Create(OpCodes.Arglist);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Break"/>.
        /// <para>
        /// Inform a debugger that a breakpoint has been reached.
        /// </para>
        /// </summary>
        public static Instruction Break()
            => Instruction.Create(OpCodes.Break);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ceq"/>.
        /// <para>
        /// Push 1 (of type int32) if value1 equals value2, else push 0.
        /// </para>
        /// </summary>
        public static Instruction Ceq()
            => Instruction.Create(OpCodes.Ceq);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Cgt"/>.
        /// <para>
        /// Push 1 (of type int32) if value1 > value2, else push 0.
        /// </para>
        /// </summary>
        public static Instruction Cgt()
            => Instruction.Create(OpCodes.Cgt);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Cgt_Un"/>.
        /// <para>
        /// Push 1 (of type int32) if value1 > value2, unsigned or unordered, else push 0.
        /// </para>
        /// </summary>
        public static Instruction Cgt_Un()
            => Instruction.Create(OpCodes.Cgt_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ckfinite"/>.
        /// <para>
        /// Throw ArithmeticException if value is not a finite number.
        /// </para>
        /// </summary>
        public static Instruction Ckfinite()
            => Instruction.Create(OpCodes.Ckfinite);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Clt"/>.
        /// <para>
        /// Push 1 (of type int32) if value1 < value2, else push 0.
        /// </para>
        /// </summary>
        public static Instruction Clt()
            => Instruction.Create(OpCodes.Clt);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Clt_Un"/>.
        /// <para>
        /// Push 1 (of type int32) if value1 < value2, unsigned or unordered, else push 0.
        /// </para>
        /// </summary>
        public static Instruction Clt_Un()
            => Instruction.Create(OpCodes.Clt_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_I"/>.
        /// <para>
        /// Convert to native int, pushing native int on stack.
        /// </para>
        /// </summary>
        public static Instruction Conv_I()
            => Instruction.Create(OpCodes.Conv_I);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_I1"/>.
        /// <para>
        /// Convert to int8, pushing int32 on stack.
        /// </para>
        /// </summary>
        public static Instruction Conv_I1()
            => Instruction.Create(OpCodes.Conv_I1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_I2"/>.
        /// <para>
        /// Convert to int16, pushing int32 on stack.
        /// </para>
        /// </summary>
        public static Instruction Conv_I2()
            => Instruction.Create(OpCodes.Conv_I2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_I4"/>.
        /// <para>
        /// Convert to int32, pushing int32 on stack.
        /// </para>
        /// </summary>
        public static Instruction Conv_I4()
            => Instruction.Create(OpCodes.Conv_I4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_I8"/>.
        /// <para>
        /// Convert to int64, pushing int64 on stack.
        /// </para>
        /// </summary>
        public static Instruction Conv_I8()
            => Instruction.Create(OpCodes.Conv_I8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I"/>.
        /// <para>
        /// Convert to a native int (on the stack as native int) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_I()
            => Instruction.Create(OpCodes.Conv_Ovf_I);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I_Un"/>.
        /// <para>
        /// Convert unsigned to a native int (on the stack as native int) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_I_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_I_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I1"/>.
        /// <para>
        /// Convert to an int8 (on the stack as int32) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_I1()
            => Instruction.Create(OpCodes.Conv_Ovf_I1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I1_Un"/>.
        /// <para>
        /// Convert unsigned to an int8 (on the stack as int32) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_I1_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_I1_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I2"/>.
        /// <para>
        /// Convert to an int16 (on the stack as int32) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_I2()
            => Instruction.Create(OpCodes.Conv_Ovf_I2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I2_Un"/>.
        /// <para>
        /// Convert unsigned to an int16 (on the stack as int32) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_I2_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_I2_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I4"/>.
        /// <para>
        /// Convert to an int32 (on the stack as int32) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_I4()
            => Instruction.Create(OpCodes.Conv_Ovf_I4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I4_Un"/>.
        /// <para>
        /// Convert unsigned to an int32 (on the stack as int32) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_I4_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_I4_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I8"/>.
        /// <para>
        /// Convert to an int64 (on the stack as int64) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_I8()
            => Instruction.Create(OpCodes.Conv_Ovf_I8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I8_Un"/>.
        /// <para>
        /// Convert unsigned to an int64 (on the stack as int64) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_I8_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_I8_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U"/>.
        /// <para>
        /// Convert to a native unsigned int (on the stack as native int) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_U()
            => Instruction.Create(OpCodes.Conv_Ovf_U);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U_Un"/>.
        /// <para>
        /// Convert unsigned to a native unsigned int (on the stack as native int) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_U_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_U_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U1"/>.
        /// <para>
        /// Convert to an unsigned int8 (on the stack as int32) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_U1()
            => Instruction.Create(OpCodes.Conv_Ovf_U1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U1_Un"/>.
        /// <para>
        /// Convert unsigned to an unsigned int8 (on the stack as int32) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_U1_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_U1_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U2"/>.
        /// <para>
        /// Convert to an unsigned int16 (on the stack as int32) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_U2()
            => Instruction.Create(OpCodes.Conv_Ovf_U2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U2_Un"/>.
        /// <para>
        /// Convert unsigned to an unsigned int16 (on the stack as int32) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_U2_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_U2_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U4"/>.
        /// <para>
        /// Convert to an unsigned int32 (on the stack as int32) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_U4()
            => Instruction.Create(OpCodes.Conv_Ovf_U4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U4_Un"/>.
        /// <para>
        /// Convert unsigned to an unsigned int32 (on the stack as int32) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_U4_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_U4_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U8"/>.
        /// <para>
        /// Convert to an unsigned int64 (on the stack as int64) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_U8()
            => Instruction.Create(OpCodes.Conv_Ovf_U8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U8_Un"/>.
        /// <para>
        /// Convert unsigned to an unsigned int64 (on the stack as int64) and throw an exception on overflow.
        /// </para>
        /// </summary>
        public static Instruction Conv_Ovf_U8_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_U8_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_R_Un"/>.
        /// <para>
        /// Convert unsigned integer to floating-point, pushing F on stack.
        /// </para>
        /// </summary>
        public static Instruction Conv_R_Un()
            => Instruction.Create(OpCodes.Conv_R_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_R4"/>.
        /// <para>
        /// Convert to float32, pushing F on stack.
        /// </para>
        /// </summary>
        public static Instruction Conv_R4()
            => Instruction.Create(OpCodes.Conv_R4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_R8"/>.
        /// <para>
        /// Convert to float64, pushing F on stack.
        /// </para>
        /// </summary>
        public static Instruction Conv_R8()
            => Instruction.Create(OpCodes.Conv_R8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_U"/>.
        /// <para>
        /// Convert to native unsigned int, pushing native int on stack.
        /// </para>
        /// </summary>
        public static Instruction Conv_U()
            => Instruction.Create(OpCodes.Conv_U);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_U1"/>.
        /// <para>
        /// Convert to unsigned int8, pushing int32 on stack.
        /// </para>
        /// </summary>
        public static Instruction Conv_U1()
            => Instruction.Create(OpCodes.Conv_U1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_U2"/>.
        /// <para>
        /// Convert to unsigned int16, pushing int32 on stack.
        /// </para>
        /// </summary>
        public static Instruction Conv_U2()
            => Instruction.Create(OpCodes.Conv_U2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_U4"/>.
        /// <para>
        /// Convert to unsigned int32, pushing int32 on stack.
        /// </para>
        /// </summary>
        public static Instruction Conv_U4()
            => Instruction.Create(OpCodes.Conv_U4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_U8"/>.
        /// <para>
        /// Convert to unsigned int64, pushing int64 on stack.
        /// </para>
        /// </summary>
        public static Instruction Conv_U8()
            => Instruction.Create(OpCodes.Conv_U8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Cpblk"/>.
        /// <para>
        /// Copy data from memory to memory.
        /// </para>
        /// </summary>
        public static Instruction Cpblk()
            => Instruction.Create(OpCodes.Cpblk);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Div"/>.
        /// <para>
        /// Divide two values to return a quotient or floating-point result.
        /// </para>
        /// </summary>
        public static Instruction Div()
            => Instruction.Create(OpCodes.Div);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Div_Un"/>.
        /// <para>
        /// Divide two values, unsigned, returning a quotient.
        /// </para>
        /// </summary>
        public static Instruction Div_Un()
            => Instruction.Create(OpCodes.Div_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Dup"/>.
        /// <para>
        /// Duplicate the value on the top of the stack.
        /// </para>
        /// </summary>
        public static Instruction Dup()
            => Instruction.Create(OpCodes.Dup);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Endfilter"/>.
        /// <para>
        /// End an exception handling filter clause.
        /// </para>
        /// </summary>
        public static Instruction Endfilter()
            => Instruction.Create(OpCodes.Endfilter);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Endfinally"/>.
        /// <para>
        /// End finally clause of an exception block.
        /// </para>
        /// </summary>
        public static Instruction Endfinally()
            => Instruction.Create(OpCodes.Endfinally);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Initblk"/>.
        /// <para>
        /// Set all bytes in a block of memory to a given byte value.
        /// </para>
        /// </summary>
        public static Instruction Initblk()
            => Instruction.Create(OpCodes.Initblk);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldarg_0"/>.
        /// <para>
        /// Load argument 0 onto the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldarg_0()
            => Instruction.Create(OpCodes.Ldarg_0);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldarg_1"/>.
        /// <para>
        /// Load argument 1 onto the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldarg_1()
            => Instruction.Create(OpCodes.Ldarg_1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldarg_2"/>.
        /// <para>
        /// Load argument 2 onto the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldarg_2()
            => Instruction.Create(OpCodes.Ldarg_2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldarg_3"/>.
        /// <para>
        /// Load argument 3 onto the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldarg_3()
            => Instruction.Create(OpCodes.Ldarg_3);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_0"/>.
        /// <para>
        /// Push 0 onto the stack as int32.
        /// </para>
        /// </summary>
        public static Instruction Ldc_I4_0()
            => Instruction.Create(OpCodes.Ldc_I4_0);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_1"/>.
        /// <para>
        /// Push 1 onto the stack as int32.
        /// </para>
        /// </summary>
        public static Instruction Ldc_I4_1()
            => Instruction.Create(OpCodes.Ldc_I4_1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_2"/>.
        /// <para>
        /// Push 2 onto the stack as int32.
        /// </para>
        /// </summary>
        public static Instruction Ldc_I4_2()
            => Instruction.Create(OpCodes.Ldc_I4_2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_3"/>.
        /// <para>
        /// Push 3 onto the stack as int32.
        /// </para>
        /// </summary>
        public static Instruction Ldc_I4_3()
            => Instruction.Create(OpCodes.Ldc_I4_3);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_4"/>.
        /// <para>
        /// Push 4 onto the stack as int32.
        /// </para>
        /// </summary>
        public static Instruction Ldc_I4_4()
            => Instruction.Create(OpCodes.Ldc_I4_4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_5"/>.
        /// <para>
        /// Push 5 onto the stack as int32.
        /// </para>
        /// </summary>
        public static Instruction Ldc_I4_5()
            => Instruction.Create(OpCodes.Ldc_I4_5);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_6"/>.
        /// <para>
        /// Push 6 onto the stack as int32.
        /// </para>
        /// </summary>
        public static Instruction Ldc_I4_6()
            => Instruction.Create(OpCodes.Ldc_I4_6);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_7"/>.
        /// <para>
        /// Push 7 onto the stack as int32.
        /// </para>
        /// </summary>
        public static Instruction Ldc_I4_7()
            => Instruction.Create(OpCodes.Ldc_I4_7);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_8"/>.
        /// <para>
        /// Push 8 onto the stack as int32.
        /// </para>
        /// </summary>
        public static Instruction Ldc_I4_8()
            => Instruction.Create(OpCodes.Ldc_I4_8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_M1"/>.
        /// <para>
        /// Push -1 onto the stack as int32.
        /// </para>
        /// </summary>
        public static Instruction Ldc_I4_M1()
            => Instruction.Create(OpCodes.Ldc_I4_M1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_I"/>.
        /// <para>
        /// Load the element with type native int at index onto the top of the stack as a native int.
        /// </para>
        /// </summary>
        public static Instruction Ldelem_I()
            => Instruction.Create(OpCodes.Ldelem_I);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_I1"/>.
        /// <para>
        /// Load the element with type int8 at index onto the top of the stack as an int32.
        /// </para>
        /// </summary>
        public static Instruction Ldelem_I1()
            => Instruction.Create(OpCodes.Ldelem_I1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_I2"/>.
        /// <para>
        /// Load the element with type int16 at index onto the top of the stack as an int32.
        /// </para>
        /// </summary>
        public static Instruction Ldelem_I2()
            => Instruction.Create(OpCodes.Ldelem_I2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_I4"/>.
        /// <para>
        /// Load the element with type int32 at index onto the top of the stack as an int32.
        /// </para>
        /// </summary>
        public static Instruction Ldelem_I4()
            => Instruction.Create(OpCodes.Ldelem_I4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_I8"/>.
        /// <para>
        /// Load the element with type int64 at index onto the top of the stack as an int64.
        /// </para>
        /// </summary>
        public static Instruction Ldelem_I8()
            => Instruction.Create(OpCodes.Ldelem_I8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_R4"/>.
        /// <para>
        /// Load the element with type float32 at index onto the top of the stack as an F
        /// </para>
        /// </summary>
        public static Instruction Ldelem_R4()
            => Instruction.Create(OpCodes.Ldelem_R4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_R8"/>.
        /// <para>
        /// Load the element with type float64 at index onto the top of the stack as an F.
        /// </para>
        /// </summary>
        public static Instruction Ldelem_R8()
            => Instruction.Create(OpCodes.Ldelem_R8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_Ref"/>.
        /// <para>
        /// Load the element at index onto the top of the stack as an O. The type of the O is the same as the element type of the array pushed on the CIL stack.
        /// </para>
        /// </summary>
        public static Instruction Ldelem_Ref()
            => Instruction.Create(OpCodes.Ldelem_Ref);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_U1"/>.
        /// <para>
        /// Load the element with type unsigned int8 at index onto the top of the stack as an int32.
        /// </para>
        /// </summary>
        public static Instruction Ldelem_U1()
            => Instruction.Create(OpCodes.Ldelem_U1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_U2"/>.
        /// <para>
        /// Load the element with type unsigned int16 at index onto the top of the stack as an int32.
        /// </para>
        /// </summary>
        public static Instruction Ldelem_U2()
            => Instruction.Create(OpCodes.Ldelem_U2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_U4"/>.
        /// <para>
        /// Load the element with type unsigned int32 at index onto the top of the stack as an int32.
        /// </para>
        /// </summary>
        public static Instruction Ldelem_U4()
            => Instruction.Create(OpCodes.Ldelem_U4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_I"/>.
        /// <para>
        /// Indirect load value of type native int as native int on the stack
        /// </para>
        /// </summary>
        public static Instruction Ldind_I()
            => Instruction.Create(OpCodes.Ldind_I);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_I1"/>.
        /// <para>
        /// Indirect load value of type int8 as int32 on the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldind_I1()
            => Instruction.Create(OpCodes.Ldind_I1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_I2"/>.
        /// <para>
        /// Indirect load value of type int16 as int32 on the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldind_I2()
            => Instruction.Create(OpCodes.Ldind_I2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_I4"/>.
        /// <para>
        /// Indirect load value of type int32 as int32 on the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldind_I4()
            => Instruction.Create(OpCodes.Ldind_I4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_I8"/>.
        /// <para>
        /// Indirect load value of type int64 as int64 on the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldind_I8()
            => Instruction.Create(OpCodes.Ldind_I8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_R4"/>.
        /// <para>
        /// Indirect load value of type float32 as F on the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldind_R4()
            => Instruction.Create(OpCodes.Ldind_R4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_R8"/>.
        /// <para>
        /// Indirect load value of type float64 as F on the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldind_R8()
            => Instruction.Create(OpCodes.Ldind_R8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_Ref"/>.
        /// <para>
        /// Indirect load value of type object ref as O on the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldind_Ref()
            => Instruction.Create(OpCodes.Ldind_Ref);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_U1"/>.
        /// <para>
        /// Indirect load value of type unsigned int8 as int32 on the stack
        /// </para>
        /// </summary>
        public static Instruction Ldind_U1()
            => Instruction.Create(OpCodes.Ldind_U1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_U2"/>.
        /// <para>
        /// Indirect load value of type unsigned int16 as int32 on the stack
        /// </para>
        /// </summary>
        public static Instruction Ldind_U2()
            => Instruction.Create(OpCodes.Ldind_U2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_U4"/>.
        /// <para>
        /// Indirect load value of type unsigned int32 as int32 on the stack
        /// </para>
        /// </summary>
        public static Instruction Ldind_U4()
            => Instruction.Create(OpCodes.Ldind_U4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldlen"/>.
        /// <para>
        /// Push the length (of type native unsigned int) of array on the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldlen()
            => Instruction.Create(OpCodes.Ldlen);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldloc_0"/>.
        /// <para>
        /// Load local variable 0 onto stack.
        /// </para>
        /// </summary>
        public static Instruction Ldloc_0()
            => Instruction.Create(OpCodes.Ldloc_0);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldloc_1"/>.
        /// <para>
        /// Load local variable 1 onto stack.
        /// </para>
        /// </summary>
        public static Instruction Ldloc_1()
            => Instruction.Create(OpCodes.Ldloc_1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldloc_2"/>.
        /// <para>
        /// Load local variable 2 onto stack.
        /// </para>
        /// </summary>
        public static Instruction Ldloc_2()
            => Instruction.Create(OpCodes.Ldloc_2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldloc_3"/>.
        /// <para>
        /// Load local variable 3 onto stack.
        /// </para>
        /// </summary>
        public static Instruction Ldloc_3()
            => Instruction.Create(OpCodes.Ldloc_3);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldnull"/>.
        /// <para>
        /// Push a null reference on the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldnull()
            => Instruction.Create(OpCodes.Ldnull);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Localloc"/>.
        /// <para>
        /// Allocate space from the local memory pool.
        /// </para>
        /// </summary>
        public static Instruction Localloc()
            => Instruction.Create(OpCodes.Localloc);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Mul"/>.
        /// <para>
        /// Multiply values.
        /// </para>
        /// </summary>
        public static Instruction Mul()
            => Instruction.Create(OpCodes.Mul);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Mul_Ovf"/>.
        /// <para>
        /// Multiply signed integer values. Signed result shall fit in same size
        /// </para>
        /// </summary>
        public static Instruction Mul_Ovf()
            => Instruction.Create(OpCodes.Mul_Ovf);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Mul_Ovf_Un"/>.
        /// <para>
        /// Multiply unsigned integer values. Unsigned result shall fit in same size
        /// </para>
        /// </summary>
        public static Instruction Mul_Ovf_Un()
            => Instruction.Create(OpCodes.Mul_Ovf_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Neg"/>.
        /// <para>
        /// Negate value.
        /// </para>
        /// </summary>
        public static Instruction Neg()
            => Instruction.Create(OpCodes.Neg);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Nop"/>.
        /// <para>
        /// Do nothing (No operation).
        /// </para>
        /// </summary>
        public static Instruction Nop()
            => Instruction.Create(OpCodes.Nop);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Not"/>.
        /// <para>
        /// Bitwise complement (logical not).
        /// </para>
        /// </summary>
        public static Instruction Not()
            => Instruction.Create(OpCodes.Not);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Or"/>.
        /// <para>
        /// Bitwise OR of two integer values, returns an integer.
        /// </para>
        /// </summary>
        public static Instruction Or()
            => Instruction.Create(OpCodes.Or);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Pop"/>.
        /// <para>
        /// Pop value from the stack.
        /// </para>
        /// </summary>
        public static Instruction Pop()
            => Instruction.Create(OpCodes.Pop);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Readonly"/>.
        /// <para>
        /// Specify that the subsequent array address operation performs no type check at runtime, and that it returns a controlled-mutability managed pointer
        /// </para>
        /// </summary>
        public static Instruction Readonly()
            => Instruction.Create(OpCodes.Readonly);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Refanytype"/>.
        /// <para>
        /// Push the type token stored in a typed reference.
        /// </para>
        /// </summary>
        public static Instruction Refanytype()
            => Instruction.Create(OpCodes.Refanytype);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Rem"/>.
        /// <para>
        /// Remainder when dividing one value by another.
        /// </para>
        /// </summary>
        public static Instruction Rem()
            => Instruction.Create(OpCodes.Rem);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Rem_Un"/>.
        /// <para>
        /// Remainder when dividing one unsigned value by another.
        /// </para>
        /// </summary>
        public static Instruction Rem_Un()
            => Instruction.Create(OpCodes.Rem_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ret"/>.
        /// <para>
        /// Return from method, possibly with a value.
        /// </para>
        /// </summary>
        public static Instruction Ret()
            => Instruction.Create(OpCodes.Ret);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Rethrow"/>.
        /// <para>
        /// Rethrow the current exception.
        /// </para>
        /// </summary>
        public static Instruction Rethrow()
            => Instruction.Create(OpCodes.Rethrow);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Shl"/>.
        /// <para>
        /// Shift an integer left (shifting in zeros), return an integer.
        /// </para>
        /// </summary>
        public static Instruction Shl()
            => Instruction.Create(OpCodes.Shl);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Shr"/>.
        /// <para>
        /// Shift an integer right (shift in sign), return an integer.
        /// </para>
        /// </summary>
        public static Instruction Shr()
            => Instruction.Create(OpCodes.Shr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Shr_Un"/>.
        /// <para>
        /// Shift an integer right (shift in zero), return an integer.
        /// </para>
        /// </summary>
        public static Instruction Shr_Un()
            => Instruction.Create(OpCodes.Shr_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_I"/>.
        /// <para>
        /// Replace array element at index with the i value on the stack.
        /// </para>
        /// </summary>
        public static Instruction Stelem_I()
            => Instruction.Create(OpCodes.Stelem_I);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_I1"/>.
        /// <para>
        /// Replace array element at index with the int8 value on the stack.
        /// </para>
        /// </summary>
        public static Instruction Stelem_I1()
            => Instruction.Create(OpCodes.Stelem_I1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_I2"/>.
        /// <para>
        /// Replace array element at index with the int16 value on the stack.
        /// </para>
        /// </summary>
        public static Instruction Stelem_I2()
            => Instruction.Create(OpCodes.Stelem_I2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_I4"/>.
        /// <para>
        /// Replace array element at index with the int32 value on the stack.
        /// </para>
        /// </summary>
        public static Instruction Stelem_I4()
            => Instruction.Create(OpCodes.Stelem_I4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_I8"/>.
        /// <para>
        /// Replace array element at index with the int64 value on the stack.
        /// </para>
        /// </summary>
        public static Instruction Stelem_I8()
            => Instruction.Create(OpCodes.Stelem_I8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_R4"/>.
        /// <para>
        /// Replace array element at index with the float32 value on the stack.
        /// </para>
        /// </summary>
        public static Instruction Stelem_R4()
            => Instruction.Create(OpCodes.Stelem_R4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_R8"/>.
        /// <para>
        /// Replace array element at index with the float64 value on the stack.
        /// </para>
        /// </summary>
        public static Instruction Stelem_R8()
            => Instruction.Create(OpCodes.Stelem_R8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_Ref"/>.
        /// <para>
        /// Replace array element at index with the ref value on the stack.
        /// </para>
        /// </summary>
        public static Instruction Stelem_Ref()
            => Instruction.Create(OpCodes.Stelem_Ref);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_I"/>.
        /// <para>
        /// Store value of type native int into memory at address
        /// </para>
        /// </summary>
        public static Instruction Stind_I()
            => Instruction.Create(OpCodes.Stind_I);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_I1"/>.
        /// <para>
        /// Store value of type int8 into memory at address
        /// </para>
        /// </summary>
        public static Instruction Stind_I1()
            => Instruction.Create(OpCodes.Stind_I1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_I2"/>.
        /// <para>
        /// Store value of type int16 into memory at address
        /// </para>
        /// </summary>
        public static Instruction Stind_I2()
            => Instruction.Create(OpCodes.Stind_I2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_I4"/>.
        /// <para>
        /// Store value of type int32 into memory at address
        /// </para>
        /// </summary>
        public static Instruction Stind_I4()
            => Instruction.Create(OpCodes.Stind_I4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_I8"/>.
        /// <para>
        /// Store value of type int64 into memory at address
        /// </para>
        /// </summary>
        public static Instruction Stind_I8()
            => Instruction.Create(OpCodes.Stind_I8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_R4"/>.
        /// <para>
        /// Store value of type float32 into memory at address
        /// </para>
        /// </summary>
        public static Instruction Stind_R4()
            => Instruction.Create(OpCodes.Stind_R4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_R8"/>.
        /// <para>
        /// Store value of type float64 into memory at address
        /// </para>
        /// </summary>
        public static Instruction Stind_R8()
            => Instruction.Create(OpCodes.Stind_R8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_Ref"/>.
        /// <para>
        /// Store value of type object ref (type O) into memory at address
        /// </para>
        /// </summary>
        public static Instruction Stind_Ref()
            => Instruction.Create(OpCodes.Stind_Ref);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stloc_0"/>.
        /// <para>
        /// Pop a value from stack into local variable 0.
        /// </para>
        /// </summary>
        public static Instruction Stloc_0()
            => Instruction.Create(OpCodes.Stloc_0);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stloc_1"/>.
        /// <para>
        /// Pop a value from stack into local variable 1.
        /// </para>
        /// </summary>
        public static Instruction Stloc_1()
            => Instruction.Create(OpCodes.Stloc_1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stloc_2"/>.
        /// <para>
        /// Pop a value from stack into local variable 2.
        /// </para>
        /// </summary>
        public static Instruction Stloc_2()
            => Instruction.Create(OpCodes.Stloc_2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stloc_3"/>.
        /// <para>
        /// Pop a value from stack into local variable 3.
        /// </para>
        /// </summary>
        public static Instruction Stloc_3()
            => Instruction.Create(OpCodes.Stloc_3);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Sub"/>.
        /// <para>
        /// Subtract value2 from value1, returning a new value.
        /// </para>
        /// </summary>
        public static Instruction Sub()
            => Instruction.Create(OpCodes.Sub);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Sub_Ovf"/>.
        /// <para>
        /// Subtract native int from a native int. Signed result shall fit in same size
        /// </para>
        /// </summary>
        public static Instruction Sub_Ovf()
            => Instruction.Create(OpCodes.Sub_Ovf);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Sub_Ovf_Un"/>.
        /// <para>
        /// Subtract native unsigned int from a native unsigned int. Unsigned result shall fit in same size.
        /// </para>
        /// </summary>
        public static Instruction Sub_Ovf_Un()
            => Instruction.Create(OpCodes.Sub_Ovf_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Tail"/>.
        /// <para>
        /// Subsequent call terminates current method
        /// </para>
        /// </summary>
        public static Instruction Tail()
            => Instruction.Create(OpCodes.Tail);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Throw"/>.
        /// <para>
        /// Throw an exception.
        /// </para>
        /// </summary>
        public static Instruction Throw()
            => Instruction.Create(OpCodes.Throw);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Volatile"/>.
        /// <para>
        /// Subsequent pointer reference is volatile.
        /// </para>
        /// </summary>
        public static Instruction Volatile()
            => Instruction.Create(OpCodes.Volatile);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Xor"/>.
        /// <para>
        /// Bitwise XOR of integer values, returns an integer.
        /// </para>
        /// </summary>
        public static Instruction Xor()
            => Instruction.Create(OpCodes.Xor);
                        #endregion // 
        
        #region int nbr
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Beq"/>.
        /// <para>
        /// Branch to target if equal.
        /// </para>
        /// </summary>
        public static Instruction Beq(int nbr)
            => Instruction.Create(OpCodes.Beq, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bge"/>.
        /// <para>
        /// Branch to target if greater than or equal to.
        /// </para>
        /// </summary>
        public static Instruction Bge(int nbr)
            => Instruction.Create(OpCodes.Bge, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bge_Un"/>.
        /// <para>
        /// Branch to target if greater than or equal to (unsigned or unordered).
        /// </para>
        /// </summary>
        public static Instruction Bge_Un(int nbr)
            => Instruction.Create(OpCodes.Bge_Un, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bgt"/>.
        /// <para>
        /// Branch to target if greater than.
        /// </para>
        /// </summary>
        public static Instruction Bgt(int nbr)
            => Instruction.Create(OpCodes.Bgt, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bgt_Un"/>.
        /// <para>
        /// Branch to target if greater than (unsigned or unordered).
        /// </para>
        /// </summary>
        public static Instruction Bgt_Un(int nbr)
            => Instruction.Create(OpCodes.Bgt_Un, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ble"/>.
        /// <para>
        /// Branch to target if less than or equal to.
        /// </para>
        /// </summary>
        public static Instruction Ble(int nbr)
            => Instruction.Create(OpCodes.Ble, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ble_Un"/>.
        /// <para>
        /// Branch to target if less than or equal to (unsigned or unordered).
        /// </para>
        /// </summary>
        public static Instruction Ble_Un(int nbr)
            => Instruction.Create(OpCodes.Ble_Un, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Blt"/>.
        /// <para>
        /// Branch to target if less than.
        /// </para>
        /// </summary>
        public static Instruction Blt(int nbr)
            => Instruction.Create(OpCodes.Blt, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Blt_Un"/>.
        /// <para>
        /// Branch to target if less than (unsigned or unordered).
        /// </para>
        /// </summary>
        public static Instruction Blt_Un(int nbr)
            => Instruction.Create(OpCodes.Blt_Un, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bne_Un"/>.
        /// <para>
        /// Branch to target if unequal or unordered.
        /// </para>
        /// </summary>
        public static Instruction Bne_Un(int nbr)
            => Instruction.Create(OpCodes.Bne_Un, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Br"/>.
        /// <para>
        /// Branch to target.
        /// </para>
        /// </summary>
        public static Instruction Br(int nbr)
            => Instruction.Create(OpCodes.Br, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Brfalse"/>.
        /// <para>
        /// Branch to target if value is zero (false).
        /// </para>
        /// </summary>
        public static Instruction Brfalse(int nbr)
            => Instruction.Create(OpCodes.Brfalse, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Brtrue"/>.
        /// <para>
        /// Branch to target if value is non-zero (true).
        /// </para>
        /// </summary>
        public static Instruction Brtrue(int nbr)
            => Instruction.Create(OpCodes.Brtrue, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4"/>.
        /// <para>
        /// Push num of type int32 onto the stack as int32.
        /// </para>
        /// </summary>
        public static Instruction Ldc_I4(int nbr)
            => Instruction.Create(OpCodes.Ldc_I4, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Leave"/>.
        /// <para>
        /// Exit a protected region of code.
        /// </para>
        /// </summary>
        public static Instruction Leave(int nbr)
            => Instruction.Create(OpCodes.Leave, nbr);
                        #endregion // int nbr
        
        #region sbyte nbr
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Beq_S"/>.
        /// <para>
        /// Branch to target if equal, short form.
        /// </para>
        /// </summary>
        public static Instruction Beq_S(sbyte nbr)
            => Instruction.Create(OpCodes.Beq_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bge_S"/>.
        /// <para>
        /// Branch to target if greater than or equal to, short form.
        /// </para>
        /// </summary>
        public static Instruction Bge_S(sbyte nbr)
            => Instruction.Create(OpCodes.Bge_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bge_Un_S"/>.
        /// <para>
        /// Branch to target if greater than or equal to (unsigned or unordered), short form
        /// </para>
        /// </summary>
        public static Instruction Bge_Un_S(sbyte nbr)
            => Instruction.Create(OpCodes.Bge_Un_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bgt_S"/>.
        /// <para>
        /// Branch to target if greater than, short form.
        /// </para>
        /// </summary>
        public static Instruction Bgt_S(sbyte nbr)
            => Instruction.Create(OpCodes.Bgt_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bgt_Un_S"/>.
        /// <para>
        /// Branch to target if greater than (unsigned or unordered), short form.
        /// </para>
        /// </summary>
        public static Instruction Bgt_Un_S(sbyte nbr)
            => Instruction.Create(OpCodes.Bgt_Un_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ble_S"/>.
        /// <para>
        /// Branch to target if less than or equal to, short form.
        /// </para>
        /// </summary>
        public static Instruction Ble_S(sbyte nbr)
            => Instruction.Create(OpCodes.Ble_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ble_Un_S"/>.
        /// <para>
        /// Branch to target if less than or equal to (unsigned or unordered), short form
        /// </para>
        /// </summary>
        public static Instruction Ble_Un_S(sbyte nbr)
            => Instruction.Create(OpCodes.Ble_Un_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Blt_S"/>.
        /// <para>
        /// Branch to target if less than, short form.
        /// </para>
        /// </summary>
        public static Instruction Blt_S(sbyte nbr)
            => Instruction.Create(OpCodes.Blt_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Blt_Un_S"/>.
        /// <para>
        /// Branch to target if less than (unsigned or unordered), short form.
        /// </para>
        /// </summary>
        public static Instruction Blt_Un_S(sbyte nbr)
            => Instruction.Create(OpCodes.Blt_Un_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bne_Un_S"/>.
        /// <para>
        /// Branch to target if unequal or unordered, short form.
        /// </para>
        /// </summary>
        public static Instruction Bne_Un_S(sbyte nbr)
            => Instruction.Create(OpCodes.Bne_Un_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Br_S"/>.
        /// <para>
        /// Branch to target, short form.
        /// </para>
        /// </summary>
        public static Instruction Br_S(sbyte nbr)
            => Instruction.Create(OpCodes.Br_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Brfalse_S"/>.
        /// <para>
        /// Branch to target if value is zero (false), short form.
        /// </para>
        /// </summary>
        public static Instruction Brfalse_S(sbyte nbr)
            => Instruction.Create(OpCodes.Brfalse_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Brtrue_S"/>.
        /// <para>
        /// Branch to target if value is non-zero (true), short form.
        /// </para>
        /// </summary>
        public static Instruction Brtrue_S(sbyte nbr)
            => Instruction.Create(OpCodes.Brtrue_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_S"/>.
        /// <para>
        /// Push num onto the stack as int32, short form.
        /// </para>
        /// </summary>
        public static Instruction Ldc_I4_S(sbyte nbr)
            => Instruction.Create(OpCodes.Ldc_I4_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Leave_S"/>.
        /// <para>
        /// Exit a protected region of code, short form.
        /// </para>
        /// </summary>
        public static Instruction Leave_S(sbyte nbr)
            => Instruction.Create(OpCodes.Leave_S, nbr);
                        #endregion // sbyte nbr
        
        #region MethodReference method
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Call"/>.
        /// <para>
        /// Call method described by method.
        /// </para>
        /// </summary>
        public static Instruction Call(MethodReference method)
            => Instruction.Create(OpCodes.Call, method);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Callvirt"/>.
        /// <para>
        /// Call a method associated with an object.
        /// </para>
        /// </summary>
        public static Instruction Callvirt(MethodReference method)
            => Instruction.Create(OpCodes.Callvirt, method);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Jmp"/>.
        /// <para>
        /// Exit current method and jump to the specified method.
        /// </para>
        /// </summary>
        public static Instruction Jmp(MethodReference method)
            => Instruction.Create(OpCodes.Jmp, method);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldftn"/>.
        /// <para>
        /// Push a pointer to a method referenced by method, on the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldftn(MethodReference method)
            => Instruction.Create(OpCodes.Ldftn, method);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldvirtftn"/>.
        /// <para>
        /// Push address of virtual method on the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldvirtftn(MethodReference method)
            => Instruction.Create(OpCodes.Ldvirtftn, method);
                        #endregion // MethodReference method
        
        #region CallSite call
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Calli"/>.
        /// <para>
        /// Call method indicated on the stack with arguments described by callsitedescr.
        /// </para>
        /// </summary>
        public static Instruction Calli(CallSite call)
            => Instruction.Create(OpCodes.Calli, call);
                        #endregion // CallSite call
        
        #region TypeReference type
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Castclass"/>.
        /// <para>
        /// Cast obj to class.
        /// </para>
        /// </summary>
        public static Instruction Castclass(TypeReference type)
            => Instruction.Create(OpCodes.Castclass, type);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Isinst"/>.
        /// <para>
        /// Test if obj is an instance of class, returning null or an instance of that class or interface.
        /// </para>
        /// </summary>
        public static Instruction Isinst(TypeReference type)
            => Instruction.Create(OpCodes.Isinst, type);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelema"/>.
        /// <para>
        /// Load the address of element at index onto the top of the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldelema(TypeReference type)
            => Instruction.Create(OpCodes.Ldelema, type);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Mkrefany"/>.
        /// <para>
        /// Push a typed reference to ptr of type class onto the stack.
        /// </para>
        /// </summary>
        public static Instruction Mkrefany(TypeReference type)
            => Instruction.Create(OpCodes.Mkrefany, type);
                        #endregion // TypeReference type
        
        #region byte nbr
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldarg_S"/>.
        /// <para>
        /// Load argument numbered num onto the stack, short form.
        /// </para>
        /// </summary>
        public static Instruction Ldarg_S(byte nbr)
            => Instruction.Create(OpCodes.Ldarg_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldarga_S"/>.
        /// <para>
        /// Fetch the address of argument argNum, short form.
        /// </para>
        /// </summary>
        public static Instruction Ldarga_S(byte nbr)
            => Instruction.Create(OpCodes.Ldarga_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldloc_S"/>.
        /// <para>
        /// Load local variable of index indx onto stack, short form.
        /// </para>
        /// </summary>
        public static Instruction Ldloc_S(byte nbr)
            => Instruction.Create(OpCodes.Ldloc_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldloca_S"/>.
        /// <para>
        /// Load address of local variable with index indx, short form.
        /// </para>
        /// </summary>
        public static Instruction Ldloca_S(byte nbr)
            => Instruction.Create(OpCodes.Ldloca_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Starg_S"/>.
        /// <para>
        /// Store value to the argument numbered num, short form.
        /// </para>
        /// </summary>
        public static Instruction Starg_S(byte nbr)
            => Instruction.Create(OpCodes.Starg_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stloc_S"/>.
        /// <para>
        /// Pop a value from stack into local variable indx, short form.
        /// </para>
        /// </summary>
        public static Instruction Stloc_S(byte nbr)
            => Instruction.Create(OpCodes.Stloc_S, nbr);
                        #endregion // byte nbr
        
        #region long nbr
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I8"/>.
        /// <para>
        /// Push num of type int64 onto the stack as int64.
        /// </para>
        /// </summary>
        public static Instruction Ldc_I8(long nbr)
            => Instruction.Create(OpCodes.Ldc_I8, nbr);
                        #endregion // long nbr
        
        #region float nbr
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_R4"/>.
        /// <para>
        /// Push num of type float32 onto the stack as F.
        /// </para>
        /// </summary>
        public static Instruction Ldc_R4(float nbr)
            => Instruction.Create(OpCodes.Ldc_R4, nbr);
                        #endregion // float nbr
        
        #region double nbr
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_R8"/>.
        /// <para>
        /// Push num of type float64 onto the stack as F.
        /// </para>
        /// </summary>
        public static Instruction Ldc_R8(double nbr)
            => Instruction.Create(OpCodes.Ldc_R8, nbr);
                        #endregion // double nbr
        
        #region FieldReference field
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldfld"/>.
        /// <para>
        /// Push the value of field of object (or value type) obj, onto the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldfld(FieldReference field)
            => Instruction.Create(OpCodes.Ldfld, field);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldflda"/>.
        /// <para>
        /// Push the address of field of object obj on the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldflda(FieldReference field)
            => Instruction.Create(OpCodes.Ldflda, field);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldsfld"/>.
        /// <para>
        /// Push the value of field on the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldsfld(FieldReference field)
            => Instruction.Create(OpCodes.Ldsfld, field);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldsflda"/>.
        /// <para>
        /// Push the address of the static field, field, on the stack.
        /// </para>
        /// </summary>
        public static Instruction Ldsflda(FieldReference field)
            => Instruction.Create(OpCodes.Ldsflda, field);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stfld"/>.
        /// <para>
        /// Replace the value of field of the object obj with value.
        /// </para>
        /// </summary>
        public static Instruction Stfld(FieldReference field)
            => Instruction.Create(OpCodes.Stfld, field);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stsfld"/>.
        /// <para>
        /// Replace the value of field with val.
        /// </para>
        /// </summary>
        public static Instruction Stsfld(FieldReference field)
            => Instruction.Create(OpCodes.Stsfld, field);
                        #endregion // FieldReference field
        
        #region string str
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldstr"/>.
        /// <para>
        /// Push a string object for the literal string.
        /// </para>
        /// </summary>
        public static Instruction Ldstr(string str)
            => Instruction.Create(OpCodes.Ldstr, str);
                        #endregion // string str
        
    }
}