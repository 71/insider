using Mono.Cecil;
using Mono.Cecil.Cil;


namespace Insider.Extensions
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
        /// Add two values, returning a new value.
        /// </summary>
        public static Instruction Add()
            => Instruction.Create(OpCodes.Add);
                
        /// <summary>
        /// Add signed integer values with overflow check.
        /// </summary>
        public static Instruction Add_Ovf()
            => Instruction.Create(OpCodes.Add_Ovf);
                
        /// <summary>
        /// Add unsigned integer values with overflow check.
        /// </summary>
        public static Instruction Add_Ovf_Un()
            => Instruction.Create(OpCodes.Add_Ovf_Un);
                
        /// <summary>
        /// Bitwise AND of two integral values, returns an integral value.
        /// </summary>
        public static Instruction And()
            => Instruction.Create(OpCodes.And);
                
        /// <summary>
        /// Return argument list handle for the current method.
        /// </summary>
        public static Instruction Arglist()
            => Instruction.Create(OpCodes.Arglist);
                
        /// <summary>
        /// Inform a debugger that a breakpoint has been reached.
        /// </summary>
        public static Instruction Break()
            => Instruction.Create(OpCodes.Break);
                
        /// <summary>
        /// Push 1 (of type int32) if value1 equals value2, else push 0.
        /// </summary>
        public static Instruction Ceq()
            => Instruction.Create(OpCodes.Ceq);
                
        /// <summary>
        /// Push 1 (of type int32) if value1 > value2, else push 0.
        /// </summary>
        public static Instruction Cgt()
            => Instruction.Create(OpCodes.Cgt);
                
        /// <summary>
        /// Push 1 (of type int32) if value1 > value2, unsigned or unordered, else push 0.
        /// </summary>
        public static Instruction Cgt_Un()
            => Instruction.Create(OpCodes.Cgt_Un);
                
        /// <summary>
        /// Throw ArithmeticException if value is not a finite number.
        /// </summary>
        public static Instruction Ckfinite()
            => Instruction.Create(OpCodes.Ckfinite);
                
        /// <summary>
        /// Push 1 (of type int32) if value1 < value2, else push 0.
        /// </summary>
        public static Instruction Clt()
            => Instruction.Create(OpCodes.Clt);
                
        /// <summary>
        /// Push 1 (of type int32) if value1 < value2, unsigned or unordered, else push 0.
        /// </summary>
        public static Instruction Clt_Un()
            => Instruction.Create(OpCodes.Clt_Un);
                
        /// <summary>
        /// Convert to native int, pushing native int on stack.
        /// </summary>
        public static Instruction Conv_I()
            => Instruction.Create(OpCodes.Conv_I);
                
        /// <summary>
        /// Convert to int8, pushing int32 on stack.
        /// </summary>
        public static Instruction Conv_I1()
            => Instruction.Create(OpCodes.Conv_I1);
                
        /// <summary>
        /// Convert to int16, pushing int32 on stack.
        /// </summary>
        public static Instruction Conv_I2()
            => Instruction.Create(OpCodes.Conv_I2);
                
        /// <summary>
        /// Convert to int32, pushing int32 on stack.
        /// </summary>
        public static Instruction Conv_I4()
            => Instruction.Create(OpCodes.Conv_I4);
                
        /// <summary>
        /// Convert to int64, pushing int64 on stack.
        /// </summary>
        public static Instruction Conv_I8()
            => Instruction.Create(OpCodes.Conv_I8);
                
        /// <summary>
        /// Convert to a native int (on the stack as native int) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_I()
            => Instruction.Create(OpCodes.Conv_Ovf_I);
                
        /// <summary>
        /// Convert unsigned to a native int (on the stack as native int) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_I_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_I_Un);
                
        /// <summary>
        /// Convert to an int8 (on the stack as int32) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_I1()
            => Instruction.Create(OpCodes.Conv_Ovf_I1);
                
        /// <summary>
        /// Convert unsigned to an int8 (on the stack as int32) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_I1_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_I1_Un);
                
        /// <summary>
        /// Convert to an int16 (on the stack as int32) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_I2()
            => Instruction.Create(OpCodes.Conv_Ovf_I2);
                
        /// <summary>
        /// Convert unsigned to an int16 (on the stack as int32) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_I2_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_I2_Un);
                
        /// <summary>
        /// Convert to an int32 (on the stack as int32) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_I4()
            => Instruction.Create(OpCodes.Conv_Ovf_I4);
                
        /// <summary>
        /// Convert unsigned to an int32 (on the stack as int32) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_I4_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_I4_Un);
                
        /// <summary>
        /// Convert to an int64 (on the stack as int64) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_I8()
            => Instruction.Create(OpCodes.Conv_Ovf_I8);
                
        /// <summary>
        /// Convert unsigned to an int64 (on the stack as int64) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_I8_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_I8_Un);
                
        /// <summary>
        /// Convert to a native unsigned int (on the stack as native int) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_U()
            => Instruction.Create(OpCodes.Conv_Ovf_U);
                
        /// <summary>
        /// Convert unsigned to a native unsigned int (on the stack as native int) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_U_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_U_Un);
                
        /// <summary>
        /// Convert to an unsigned int8 (on the stack as int32) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_U1()
            => Instruction.Create(OpCodes.Conv_Ovf_U1);
                
        /// <summary>
        /// Convert unsigned to an unsigned int8 (on the stack as int32) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_U1_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_U1_Un);
                
        /// <summary>
        /// Convert to an unsigned int16 (on the stack as int32) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_U2()
            => Instruction.Create(OpCodes.Conv_Ovf_U2);
                
        /// <summary>
        /// Convert unsigned to an unsigned int16 (on the stack as int32) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_U2_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_U2_Un);
                
        /// <summary>
        /// Convert to an unsigned int32 (on the stack as int32) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_U4()
            => Instruction.Create(OpCodes.Conv_Ovf_U4);
                
        /// <summary>
        /// Convert unsigned to an unsigned int32 (on the stack as int32) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_U4_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_U4_Un);
                
        /// <summary>
        /// Convert to an unsigned int64 (on the stack as int64) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_U8()
            => Instruction.Create(OpCodes.Conv_Ovf_U8);
                
        /// <summary>
        /// Convert unsigned to an unsigned int64 (on the stack as int64) and throw an exception on overflow.
        /// </summary>
        public static Instruction Conv_Ovf_U8_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_U8_Un);
                
        /// <summary>
        /// Convert unsigned integer to floating-point, pushing F on stack.
        /// </summary>
        public static Instruction Conv_R_Un()
            => Instruction.Create(OpCodes.Conv_R_Un);
                
        /// <summary>
        /// Convert to float32, pushing F on stack.
        /// </summary>
        public static Instruction Conv_R4()
            => Instruction.Create(OpCodes.Conv_R4);
                
        /// <summary>
        /// Convert to float64, pushing F on stack.
        /// </summary>
        public static Instruction Conv_R8()
            => Instruction.Create(OpCodes.Conv_R8);
                
        /// <summary>
        /// Convert to native unsigned int, pushing native int on stack.
        /// </summary>
        public static Instruction Conv_U()
            => Instruction.Create(OpCodes.Conv_U);
                
        /// <summary>
        /// Convert to unsigned int8, pushing int32 on stack.
        /// </summary>
        public static Instruction Conv_U1()
            => Instruction.Create(OpCodes.Conv_U1);
                
        /// <summary>
        /// Convert to unsigned int16, pushing int32 on stack.
        /// </summary>
        public static Instruction Conv_U2()
            => Instruction.Create(OpCodes.Conv_U2);
                
        /// <summary>
        /// Convert to unsigned int32, pushing int32 on stack.
        /// </summary>
        public static Instruction Conv_U4()
            => Instruction.Create(OpCodes.Conv_U4);
                
        /// <summary>
        /// Convert to unsigned int64, pushing int64 on stack.
        /// </summary>
        public static Instruction Conv_U8()
            => Instruction.Create(OpCodes.Conv_U8);
                
        /// <summary>
        /// Copy data from memory to memory.
        /// </summary>
        public static Instruction Cpblk()
            => Instruction.Create(OpCodes.Cpblk);
                
        /// <summary>
        /// Divide two values to return a quotient or floating-point result.
        /// </summary>
        public static Instruction Div()
            => Instruction.Create(OpCodes.Div);
                
        /// <summary>
        /// Divide two values, unsigned, returning a quotient.
        /// </summary>
        public static Instruction Div_Un()
            => Instruction.Create(OpCodes.Div_Un);
                
        /// <summary>
        /// Duplicate the value on the top of the stack.
        /// </summary>
        public static Instruction Dup()
            => Instruction.Create(OpCodes.Dup);
                
        /// <summary>
        /// End an exception handling filter clause.
        /// </summary>
        public static Instruction Endfilter()
            => Instruction.Create(OpCodes.Endfilter);
                
        /// <summary>
        /// End finally clause of an exception block.
        /// </summary>
        public static Instruction Endfinally()
            => Instruction.Create(OpCodes.Endfinally);
                
        /// <summary>
        /// Set all bytes in a block of memory to a given byte value.
        /// </summary>
        public static Instruction Initblk()
            => Instruction.Create(OpCodes.Initblk);
                
        /// <summary>
        /// Load argument 0 onto the stack.
        /// </summary>
        public static Instruction Ldarg_0()
            => Instruction.Create(OpCodes.Ldarg_0);
                
        /// <summary>
        /// Load argument 1 onto the stack.
        /// </summary>
        public static Instruction Ldarg_1()
            => Instruction.Create(OpCodes.Ldarg_1);
                
        /// <summary>
        /// Load argument 2 onto the stack.
        /// </summary>
        public static Instruction Ldarg_2()
            => Instruction.Create(OpCodes.Ldarg_2);
                
        /// <summary>
        /// Load argument 3 onto the stack.
        /// </summary>
        public static Instruction Ldarg_3()
            => Instruction.Create(OpCodes.Ldarg_3);
                
        /// <summary>
        /// Push 0 onto the stack as int32.
        /// </summary>
        public static Instruction Ldc_I4_0()
            => Instruction.Create(OpCodes.Ldc_I4_0);
                
        /// <summary>
        /// Push 1 onto the stack as int32.
        /// </summary>
        public static Instruction Ldc_I4_1()
            => Instruction.Create(OpCodes.Ldc_I4_1);
                
        /// <summary>
        /// Push 2 onto the stack as int32.
        /// </summary>
        public static Instruction Ldc_I4_2()
            => Instruction.Create(OpCodes.Ldc_I4_2);
                
        /// <summary>
        /// Push 3 onto the stack as int32.
        /// </summary>
        public static Instruction Ldc_I4_3()
            => Instruction.Create(OpCodes.Ldc_I4_3);
                
        /// <summary>
        /// Push 4 onto the stack as int32.
        /// </summary>
        public static Instruction Ldc_I4_4()
            => Instruction.Create(OpCodes.Ldc_I4_4);
                
        /// <summary>
        /// Push 5 onto the stack as int32.
        /// </summary>
        public static Instruction Ldc_I4_5()
            => Instruction.Create(OpCodes.Ldc_I4_5);
                
        /// <summary>
        /// Push 6 onto the stack as int32.
        /// </summary>
        public static Instruction Ldc_I4_6()
            => Instruction.Create(OpCodes.Ldc_I4_6);
                
        /// <summary>
        /// Push 7 onto the stack as int32.
        /// </summary>
        public static Instruction Ldc_I4_7()
            => Instruction.Create(OpCodes.Ldc_I4_7);
                
        /// <summary>
        /// Push 8 onto the stack as int32.
        /// </summary>
        public static Instruction Ldc_I4_8()
            => Instruction.Create(OpCodes.Ldc_I4_8);
                
        /// <summary>
        /// Push -1 onto the stack as int32.
        /// </summary>
        public static Instruction Ldc_I4_M1()
            => Instruction.Create(OpCodes.Ldc_I4_M1);
                
        /// <summary>
        /// Indirect load value of type native int as native int on the stack
        /// </summary>
        public static Instruction Ldind_I()
            => Instruction.Create(OpCodes.Ldind_I);
                
        /// <summary>
        /// Indirect load value of type int8 as int32 on the stack.
        /// </summary>
        public static Instruction Ldind_I1()
            => Instruction.Create(OpCodes.Ldind_I1);
                
        /// <summary>
        /// Indirect load value of type int16 as int32 on the stack.
        /// </summary>
        public static Instruction Ldind_I2()
            => Instruction.Create(OpCodes.Ldind_I2);
                
        /// <summary>
        /// Indirect load value of type int32 as int32 on the stack.
        /// </summary>
        public static Instruction Ldind_I4()
            => Instruction.Create(OpCodes.Ldind_I4);
                
        /// <summary>
        /// Indirect load value of type int64 as int64 on the stack.
        /// </summary>
        public static Instruction Ldind_I8()
            => Instruction.Create(OpCodes.Ldind_I8);
                
        /// <summary>
        /// Indirect load value of type float32 as F on the stack.
        /// </summary>
        public static Instruction Ldind_R4()
            => Instruction.Create(OpCodes.Ldind_R4);
                
        /// <summary>
        /// Indirect load value of type float64 as F on the stack.
        /// </summary>
        public static Instruction Ldind_R8()
            => Instruction.Create(OpCodes.Ldind_R8);
                
        /// <summary>
        /// Indirect load value of type object ref as O on the stack.
        /// </summary>
        public static Instruction Ldind_Ref()
            => Instruction.Create(OpCodes.Ldind_Ref);
                
        /// <summary>
        /// Indirect load value of type unsigned int8 as int32 on the stack
        /// </summary>
        public static Instruction Ldind_U1()
            => Instruction.Create(OpCodes.Ldind_U1);
                
        /// <summary>
        /// Indirect load value of type unsigned int16 as int32 on the stack
        /// </summary>
        public static Instruction Ldind_U2()
            => Instruction.Create(OpCodes.Ldind_U2);
                
        /// <summary>
        /// Indirect load value of type unsigned int32 as int32 on the stack
        /// </summary>
        public static Instruction Ldind_U4()
            => Instruction.Create(OpCodes.Ldind_U4);
                
        /// <summary>
        /// Push the length (of type native unsigned int) of array on the stack.
        /// </summary>
        public static Instruction Ldlen()
            => Instruction.Create(OpCodes.Ldlen);
                
        /// <summary>
        /// Load local variable 0 onto stack.
        /// </summary>
        public static Instruction Ldloc_0()
            => Instruction.Create(OpCodes.Ldloc_0);
                
        /// <summary>
        /// Load local variable 1 onto stack.
        /// </summary>
        public static Instruction Ldloc_1()
            => Instruction.Create(OpCodes.Ldloc_1);
                
        /// <summary>
        /// Load local variable 2 onto stack.
        /// </summary>
        public static Instruction Ldloc_2()
            => Instruction.Create(OpCodes.Ldloc_2);
                
        /// <summary>
        /// Load local variable 3 onto stack.
        /// </summary>
        public static Instruction Ldloc_3()
            => Instruction.Create(OpCodes.Ldloc_3);
                
        /// <summary>
        /// Push a null reference on the stack.
        /// </summary>
        public static Instruction Ldnull()
            => Instruction.Create(OpCodes.Ldnull);
                
        /// <summary>
        /// Allocate space from the local memory pool.
        /// </summary>
        public static Instruction Localloc()
            => Instruction.Create(OpCodes.Localloc);
                
        /// <summary>
        /// Multiply values.
        /// </summary>
        public static Instruction Mul()
            => Instruction.Create(OpCodes.Mul);
                
        /// <summary>
        /// Multiply signed integer values. Signed result shall fit in same size
        /// </summary>
        public static Instruction Mul_Ovf()
            => Instruction.Create(OpCodes.Mul_Ovf);
                
        /// <summary>
        /// Multiply unsigned integer values. Unsigned result shall fit in same size
        /// </summary>
        public static Instruction Mul_Ovf_Un()
            => Instruction.Create(OpCodes.Mul_Ovf_Un);
                
        /// <summary>
        /// Negate value.
        /// </summary>
        public static Instruction Neg()
            => Instruction.Create(OpCodes.Neg);
                
        /// <summary>
        /// Do nothing (No operation).
        /// </summary>
        public static Instruction Nop()
            => Instruction.Create(OpCodes.Nop);
                
        /// <summary>
        /// Bitwise complement (logical not).
        /// </summary>
        public static Instruction Not()
            => Instruction.Create(OpCodes.Not);
                
        /// <summary>
        /// Bitwise OR of two integer values, returns an integer.
        /// </summary>
        public static Instruction Or()
            => Instruction.Create(OpCodes.Or);
                
        /// <summary>
        /// Pop value from the stack.
        /// </summary>
        public static Instruction Pop()
            => Instruction.Create(OpCodes.Pop);
                
        /// <summary>
        /// Specify that the subsequent array address operation performs no type check at runtime, and that it returns a controlled-mutability managed pointer
        /// </summary>
        public static Instruction Readonly()
            => Instruction.Create(OpCodes.Readonly);
                
        /// <summary>
        /// Push the type token stored in a typed reference.
        /// </summary>
        public static Instruction Refanytype()
            => Instruction.Create(OpCodes.Refanytype);
                
        /// <summary>
        /// Remainder when dividing one value by another.
        /// </summary>
        public static Instruction Rem()
            => Instruction.Create(OpCodes.Rem);
                
        /// <summary>
        /// Remainder when dividing one unsigned value by another.
        /// </summary>
        public static Instruction Rem_Un()
            => Instruction.Create(OpCodes.Rem_Un);
                
        /// <summary>
        /// Return from method, possibly with a value.
        /// </summary>
        public static Instruction Ret()
            => Instruction.Create(OpCodes.Ret);
                
        /// <summary>
        /// Rethrow the current exception.
        /// </summary>
        public static Instruction Rethrow()
            => Instruction.Create(OpCodes.Rethrow);
                
        /// <summary>
        /// Shift an integer left (shifting in zeros), return an integer.
        /// </summary>
        public static Instruction Shl()
            => Instruction.Create(OpCodes.Shl);
                
        /// <summary>
        /// Shift an integer right (shift in sign), return an integer.
        /// </summary>
        public static Instruction Shr()
            => Instruction.Create(OpCodes.Shr);
                
        /// <summary>
        /// Shift an integer right (shift in zero), return an integer.
        /// </summary>
        public static Instruction Shr_Un()
            => Instruction.Create(OpCodes.Shr_Un);
                
        /// <summary>
        /// Store value of type native int into memory at address
        /// </summary>
        public static Instruction Stind_I()
            => Instruction.Create(OpCodes.Stind_I);
                
        /// <summary>
        /// Store value of type int8 into memory at address
        /// </summary>
        public static Instruction Stind_I1()
            => Instruction.Create(OpCodes.Stind_I1);
                
        /// <summary>
        /// Store value of type int16 into memory at address
        /// </summary>
        public static Instruction Stind_I2()
            => Instruction.Create(OpCodes.Stind_I2);
                
        /// <summary>
        /// Store value of type int32 into memory at address
        /// </summary>
        public static Instruction Stind_I4()
            => Instruction.Create(OpCodes.Stind_I4);
                
        /// <summary>
        /// Store value of type int64 into memory at address
        /// </summary>
        public static Instruction Stind_I8()
            => Instruction.Create(OpCodes.Stind_I8);
                
        /// <summary>
        /// Store value of type float32 into memory at address
        /// </summary>
        public static Instruction Stind_R4()
            => Instruction.Create(OpCodes.Stind_R4);
                
        /// <summary>
        /// Store value of type float64 into memory at address
        /// </summary>
        public static Instruction Stind_R8()
            => Instruction.Create(OpCodes.Stind_R8);
                
        /// <summary>
        /// Store value of type object ref (type O) into memory at address
        /// </summary>
        public static Instruction Stind_Ref()
            => Instruction.Create(OpCodes.Stind_Ref);
                
        /// <summary>
        /// Pop a value from stack into local variable 0.
        /// </summary>
        public static Instruction Stloc_0()
            => Instruction.Create(OpCodes.Stloc_0);
                
        /// <summary>
        /// Pop a value from stack into local variable 1.
        /// </summary>
        public static Instruction Stloc_1()
            => Instruction.Create(OpCodes.Stloc_1);
                
        /// <summary>
        /// Pop a value from stack into local variable 2.
        /// </summary>
        public static Instruction Stloc_2()
            => Instruction.Create(OpCodes.Stloc_2);
                
        /// <summary>
        /// Pop a value from stack into local variable 3.
        /// </summary>
        public static Instruction Stloc_3()
            => Instruction.Create(OpCodes.Stloc_3);
                
        /// <summary>
        /// Subtract value2 from value1, returning a new value.
        /// </summary>
        public static Instruction Sub()
            => Instruction.Create(OpCodes.Sub);
                
        /// <summary>
        /// Subtract native int from a native int. Signed result shall fit in same size
        /// </summary>
        public static Instruction Sub_Ovf()
            => Instruction.Create(OpCodes.Sub_Ovf);
                
        /// <summary>
        /// Subtract native unsigned int from a native unsigned int. Unsigned result shall fit in same size.
        /// </summary>
        public static Instruction Sub_Ovf_Un()
            => Instruction.Create(OpCodes.Sub_Ovf_Un);
                
        /// <summary>
        /// Subsequent call terminates current method
        /// </summary>
        public static Instruction Tail()
            => Instruction.Create(OpCodes.Tail);
                
        /// <summary>
        /// Throw an exception.
        /// </summary>
        public static Instruction Throw()
            => Instruction.Create(OpCodes.Throw);
                
        /// <summary>
        /// Subsequent pointer reference is volatile.
        /// </summary>
        public static Instruction Volatile()
            => Instruction.Create(OpCodes.Volatile);
                
        /// <summary>
        /// Bitwise XOR of integer values, returns an integer.
        /// </summary>
        public static Instruction Xor()
            => Instruction.Create(OpCodes.Xor);
                
        #endregion // 
        
        #region int nbr
            
        /// <summary>
        /// Branch to target if equal.
        /// </summary>
        public static Instruction Beq(int nbr)
            => Instruction.Create(OpCodes.Beq, nbr);
                
        /// <summary>
        /// Branch to target if greater than or equal to.
        /// </summary>
        public static Instruction Bge(int nbr)
            => Instruction.Create(OpCodes.Bge, nbr);
                
        /// <summary>
        /// Branch to target if greater than or equal to (unsigned or unordered).
        /// </summary>
        public static Instruction Bge_Un(int nbr)
            => Instruction.Create(OpCodes.Bge_Un, nbr);
                
        /// <summary>
        /// Branch to target if greater than.
        /// </summary>
        public static Instruction Bgt(int nbr)
            => Instruction.Create(OpCodes.Bgt, nbr);
                
        /// <summary>
        /// Branch to target if greater than (unsigned or unordered).
        /// </summary>
        public static Instruction Bgt_Un(int nbr)
            => Instruction.Create(OpCodes.Bgt_Un, nbr);
                
        /// <summary>
        /// Branch to target if less than or equal to.
        /// </summary>
        public static Instruction Ble(int nbr)
            => Instruction.Create(OpCodes.Ble, nbr);
                
        /// <summary>
        /// Branch to target if less than or equal to (unsigned or unordered).
        /// </summary>
        public static Instruction Ble_Un(int nbr)
            => Instruction.Create(OpCodes.Ble_Un, nbr);
                
        /// <summary>
        /// Branch to target if less than.
        /// </summary>
        public static Instruction Blt(int nbr)
            => Instruction.Create(OpCodes.Blt, nbr);
                
        /// <summary>
        /// Branch to target if less than (unsigned or unordered).
        /// </summary>
        public static Instruction Blt_Un(int nbr)
            => Instruction.Create(OpCodes.Blt_Un, nbr);
                
        /// <summary>
        /// Branch to target if unequal or unordered.
        /// </summary>
        public static Instruction Bne_Un(int nbr)
            => Instruction.Create(OpCodes.Bne_Un, nbr);
                
        /// <summary>
        /// Branch to target.
        /// </summary>
        public static Instruction Br(int nbr)
            => Instruction.Create(OpCodes.Br, nbr);
                
        /// <summary>
        /// Branch to target if value is zero (false).
        /// </summary>
        public static Instruction Brfalse(int nbr)
            => Instruction.Create(OpCodes.Brfalse, nbr);
                
        /// <summary>
        /// Branch to target if value is non-zero (true).
        /// </summary>
        public static Instruction Brtrue(int nbr)
            => Instruction.Create(OpCodes.Brtrue, nbr);
                
        /// <summary>
        /// Push num of type int32 onto the stack as int32.
        /// </summary>
        public static Instruction Ldc_I4(int nbr)
            => Instruction.Create(OpCodes.Ldc_I4, nbr);
                
        /// <summary>
        /// Exit a protected region of code.
        /// </summary>
        public static Instruction Leave(int nbr)
            => Instruction.Create(OpCodes.Leave, nbr);
                
        #endregion // int nbr
        
        #region sbyte nbr
            
        /// <summary>
        /// Branch to target if equal, short form.
        /// </summary>
        public static Instruction Beq_S(sbyte nbr)
            => Instruction.Create(OpCodes.Beq_S, nbr);
                
        /// <summary>
        /// Branch to target if greater than or equal to, short form.
        /// </summary>
        public static Instruction Bge_S(sbyte nbr)
            => Instruction.Create(OpCodes.Bge_S, nbr);
                
        /// <summary>
        /// Branch to target if greater than or equal to (unsigned or unordered), short form
        /// </summary>
        public static Instruction Bge_Un_S(sbyte nbr)
            => Instruction.Create(OpCodes.Bge_Un_S, nbr);
                
        /// <summary>
        /// Branch to target if greater than, short form.
        /// </summary>
        public static Instruction Bgt_S(sbyte nbr)
            => Instruction.Create(OpCodes.Bgt_S, nbr);
                
        /// <summary>
        /// Branch to target if greater than (unsigned or unordered), short form.
        /// </summary>
        public static Instruction Bgt_Un_S(sbyte nbr)
            => Instruction.Create(OpCodes.Bgt_Un_S, nbr);
                
        /// <summary>
        /// Branch to target if less than or equal to, short form.
        /// </summary>
        public static Instruction Ble_S(sbyte nbr)
            => Instruction.Create(OpCodes.Ble_S, nbr);
                
        /// <summary>
        /// Branch to target if less than or equal to (unsigned or unordered), short form
        /// </summary>
        public static Instruction Ble_Un_S(sbyte nbr)
            => Instruction.Create(OpCodes.Ble_Un_S, nbr);
                
        /// <summary>
        /// Branch to target if less than, short form.
        /// </summary>
        public static Instruction Blt_S(sbyte nbr)
            => Instruction.Create(OpCodes.Blt_S, nbr);
                
        /// <summary>
        /// Branch to target if less than (unsigned or unordered), short form.
        /// </summary>
        public static Instruction Blt_Un_S(sbyte nbr)
            => Instruction.Create(OpCodes.Blt_Un_S, nbr);
                
        /// <summary>
        /// Branch to target if unequal or unordered, short form.
        /// </summary>
        public static Instruction Bne_Un_S(sbyte nbr)
            => Instruction.Create(OpCodes.Bne_Un_S, nbr);
                
        /// <summary>
        /// Branch to target, short form.
        /// </summary>
        public static Instruction Br_S(sbyte nbr)
            => Instruction.Create(OpCodes.Br_S, nbr);
                
        /// <summary>
        /// Branch to target if value is zero (false), short form.
        /// </summary>
        public static Instruction Brfalse_S(sbyte nbr)
            => Instruction.Create(OpCodes.Brfalse_S, nbr);
                
        /// <summary>
        /// Branch to target if value is non-zero (true), short form.
        /// </summary>
        public static Instruction Brtrue_S(sbyte nbr)
            => Instruction.Create(OpCodes.Brtrue_S, nbr);
                
        /// <summary>
        /// Push num onto the stack as int32, short form.
        /// </summary>
        public static Instruction Ldc_I4_S(sbyte nbr)
            => Instruction.Create(OpCodes.Ldc_I4_S, nbr);
                
        /// <summary>
        /// Exit a protected region of code, short form.
        /// </summary>
        public static Instruction Leave_S(sbyte nbr)
            => Instruction.Create(OpCodes.Leave_S, nbr);
                
        #endregion // sbyte nbr
        
        #region TypeReference type
            
        /// <summary>
        /// Convert a boxable value to its boxed form
        /// </summary>
        public static Instruction Box(TypeReference type)
            => Instruction.Create(OpCodes.Box, type);
                
        /// <summary>
        /// Cast obj to class.
        /// </summary>
        public static Instruction Castclass(TypeReference type)
            => Instruction.Create(OpCodes.Castclass, type);
                
        /// <summary>
        /// Call a virtual method on a type constrained to be type T
        /// </summary>
        public static Instruction Constrained(TypeReference type)
            => Instruction.Create(OpCodes.Constrained, type);
                
        /// <summary>
        /// Copy a value type from src to dest.
        /// </summary>
        public static Instruction Cpobj(TypeReference type)
            => Instruction.Create(OpCodes.Cpobj, type);
                
        /// <summary>
        /// Initialize the value at address dest.
        /// </summary>
        public static Instruction Initobj(TypeReference type)
            => Instruction.Create(OpCodes.Initobj, type);
                
        /// <summary>
        /// Test if obj is an instance of class, returning null or an instance of that class or interface.
        /// </summary>
        public static Instruction Isinst(TypeReference type)
            => Instruction.Create(OpCodes.Isinst, type);
                
        /// <summary>
        /// Copy the value stored at address src to the stack.
        /// </summary>
        public static Instruction Ldobj(TypeReference type)
            => Instruction.Create(OpCodes.Ldobj, type);
                
        /// <summary>
        /// Convert metadata token to its runtime representation.
        /// </summary>
        public static Instruction Ldtoken(TypeReference type)
            => Instruction.Create(OpCodes.Ldtoken, type);
                
        /// <summary>
        /// Push a typed reference to ptr of type class onto the stack.
        /// </summary>
        public static Instruction Mkrefany(TypeReference type)
            => Instruction.Create(OpCodes.Mkrefany, type);
                
        /// <summary>
        /// Push the address stored in a typed reference.
        /// </summary>
        public static Instruction Refanyval(TypeReference type)
            => Instruction.Create(OpCodes.Refanyval, type);
                
        /// <summary>
        /// Push the size, in bytes, of a type as an unsigned int32.
        /// </summary>
        public static Instruction Sizeof(TypeReference type)
            => Instruction.Create(OpCodes.Sizeof, type);
                
        /// <summary>
        /// Store a value of type typeTok at an address.
        /// </summary>
        public static Instruction Stobj(TypeReference type)
            => Instruction.Create(OpCodes.Stobj, type);
                
        /// <summary>
        /// Extract a value-type from obj, its boxed representation.
        /// </summary>
        public static Instruction Unbox(TypeReference type)
            => Instruction.Create(OpCodes.Unbox, type);
                
        /// <summary>
        /// Extract a value-type from obj, its boxed representation
        /// </summary>
        public static Instruction Unbox_Any(TypeReference type)
            => Instruction.Create(OpCodes.Unbox_Any, type);
                
        #endregion // TypeReference type
        
        #region MethodReference method
            
        /// <summary>
        /// Call method described by method.
        /// </summary>
        public static Instruction Call(MethodReference method)
            => Instruction.Create(OpCodes.Call, method);
                
        /// <summary>
        /// Call a method associated with an object.
        /// </summary>
        public static Instruction Callvirt(MethodReference method)
            => Instruction.Create(OpCodes.Callvirt, method);
                
        /// <summary>
        /// Exit current method and jump to the specified method.
        /// </summary>
        public static Instruction Jmp(MethodReference method)
            => Instruction.Create(OpCodes.Jmp, method);
                
        /// <summary>
        /// Push a pointer to a method referenced by method, on the stack.
        /// </summary>
        public static Instruction Ldftn(MethodReference method)
            => Instruction.Create(OpCodes.Ldftn, method);
                
        /// <summary>
        /// Convert metadata token to its runtime representation.
        /// </summary>
        public static Instruction Ldtoken(MethodReference method)
            => Instruction.Create(OpCodes.Ldtoken, method);
                
        /// <summary>
        /// Push address of virtual method on the stack.
        /// </summary>
        public static Instruction Ldvirtftn(MethodReference method)
            => Instruction.Create(OpCodes.Ldvirtftn, method);
                
        #endregion // MethodReference method
        
        #region CallSite call
            
        /// <summary>
        /// Call method indicated on the stack with arguments described by callsitedescr.
        /// </summary>
        public static Instruction Calli(CallSite call)
            => Instruction.Create(OpCodes.Calli, call);
                
        #endregion // CallSite call
        
        #region byte nbr
            
        /// <summary>
        /// Load argument numbered num onto the stack, short form.
        /// </summary>
        public static Instruction Ldarg_S(byte nbr)
            => Instruction.Create(OpCodes.Ldarg_S, nbr);
                
        /// <summary>
        /// Fetch the address of argument argNum, short form.
        /// </summary>
        public static Instruction Ldarga_S(byte nbr)
            => Instruction.Create(OpCodes.Ldarga_S, nbr);
                
        /// <summary>
        /// Load local variable of index indx onto stack, short form.
        /// </summary>
        public static Instruction Ldloc_S(byte nbr)
            => Instruction.Create(OpCodes.Ldloc_S, nbr);
                
        /// <summary>
        /// Load address of local variable with index indx, short form.
        /// </summary>
        public static Instruction Ldloca_S(byte nbr)
            => Instruction.Create(OpCodes.Ldloca_S, nbr);
                
        /// <summary>
        /// Store value to the argument numbered num, short form.
        /// </summary>
        public static Instruction Starg_S(byte nbr)
            => Instruction.Create(OpCodes.Starg_S, nbr);
                
        /// <summary>
        /// Pop a value from stack into local variable indx, short form.
        /// </summary>
        public static Instruction Stloc_S(byte nbr)
            => Instruction.Create(OpCodes.Stloc_S, nbr);
                
        #endregion // byte nbr
        
        #region long nbr
            
        /// <summary>
        /// Push num of type int64 onto the stack as int64.
        /// </summary>
        public static Instruction Ldc_I8(long nbr)
            => Instruction.Create(OpCodes.Ldc_I8, nbr);
                
        #endregion // long nbr
        
        #region float nbr
            
        /// <summary>
        /// Push num of type float32 onto the stack as F.
        /// </summary>
        public static Instruction Ldc_R4(float nbr)
            => Instruction.Create(OpCodes.Ldc_R4, nbr);
                
        #endregion // float nbr
        
        #region double nbr
            
        /// <summary>
        /// Push num of type float64 onto the stack as F.
        /// </summary>
        public static Instruction Ldc_R8(double nbr)
            => Instruction.Create(OpCodes.Ldc_R8, nbr);
                
        #endregion // double nbr
        
        #region FieldReference field
            
        /// <summary>
        /// Push the value of field of object (or value type) obj, onto the stack.
        /// </summary>
        public static Instruction Ldfld(FieldReference field)
            => Instruction.Create(OpCodes.Ldfld, field);
                
        /// <summary>
        /// Push the address of field of object obj on the stack.
        /// </summary>
        public static Instruction Ldflda(FieldReference field)
            => Instruction.Create(OpCodes.Ldflda, field);
                
        /// <summary>
        /// Push the value of field on the stack.
        /// </summary>
        public static Instruction Ldsfld(FieldReference field)
            => Instruction.Create(OpCodes.Ldsfld, field);
                
        /// <summary>
        /// Push the address of the static field, field, on the stack.
        /// </summary>
        public static Instruction Ldsflda(FieldReference field)
            => Instruction.Create(OpCodes.Ldsflda, field);
                
        /// <summary>
        /// Convert metadata token to its runtime representation.
        /// </summary>
        public static Instruction Ldtoken(FieldReference field)
            => Instruction.Create(OpCodes.Ldtoken, field);
                
        /// <summary>
        /// Replace the value of field of the object obj with value.
        /// </summary>
        public static Instruction Stfld(FieldReference field)
            => Instruction.Create(OpCodes.Stfld, field);
                
        /// <summary>
        /// Replace the value of field with val.
        /// </summary>
        public static Instruction Stsfld(FieldReference field)
            => Instruction.Create(OpCodes.Stsfld, field);
                
        #endregion // FieldReference field
        
        #region string str
            
        /// <summary>
        /// Push a string object for the literal string.
        /// </summary>
        public static Instruction Ldstr(string str)
            => Instruction.Create(OpCodes.Ldstr, str);
                
        #endregion // string str
        
        #region TypeReference itemType
            
        /// <summary>
        /// Create a new array with elements of type etype.
        /// </summary>
        public static Instruction Newarr(TypeReference itemType)
            => Instruction.Create(OpCodes.Newarr, itemType);
                
        #endregion // TypeReference itemType
        
        #region MethodReference ctor
            
        /// <summary>
        /// Allocate an uninitialized object or value type and call ctor.
        /// </summary>
        public static Instruction Newobj(MethodReference ctor)
            => Instruction.Create(OpCodes.Newobj, ctor);
                
        #endregion // MethodReference ctor
        
    }
}