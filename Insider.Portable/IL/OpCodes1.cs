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
        // Then a little JS script to extract them
        // Now I only need to class them below
        
        #region 
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Add"/>.
        /// </summary>
        public static Instruction Add()
            => Instruction.Create(OpCodes.Add);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Add_Ovf"/>.
        /// </summary>
        public static Instruction Add_Ovf()
            => Instruction.Create(OpCodes.Add_Ovf);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Add_Ovf_Un"/>.
        /// </summary>
        public static Instruction Add_Ovf_Un()
            => Instruction.Create(OpCodes.Add_Ovf_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.And"/>.
        /// </summary>
        public static Instruction And()
            => Instruction.Create(OpCodes.And);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Arglist"/>.
        /// </summary>
        public static Instruction Arglist()
            => Instruction.Create(OpCodes.Arglist);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Break"/>.
        /// </summary>
        public static Instruction Break()
            => Instruction.Create(OpCodes.Break);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ceq"/>.
        /// </summary>
        public static Instruction Ceq()
            => Instruction.Create(OpCodes.Ceq);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Cgt"/>.
        /// </summary>
        public static Instruction Cgt()
            => Instruction.Create(OpCodes.Cgt);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Cgt_Un"/>.
        /// </summary>
        public static Instruction Cgt_Un()
            => Instruction.Create(OpCodes.Cgt_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ckfinite"/>.
        /// </summary>
        public static Instruction Ckfinite()
            => Instruction.Create(OpCodes.Ckfinite);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Clt"/>.
        /// </summary>
        public static Instruction Clt()
            => Instruction.Create(OpCodes.Clt);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Clt_Un"/>.
        /// </summary>
        public static Instruction Clt_Un()
            => Instruction.Create(OpCodes.Clt_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_I"/>.
        /// </summary>
        public static Instruction Conv_I()
            => Instruction.Create(OpCodes.Conv_I);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_I1"/>.
        /// </summary>
        public static Instruction Conv_I1()
            => Instruction.Create(OpCodes.Conv_I1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_I2"/>.
        /// </summary>
        public static Instruction Conv_I2()
            => Instruction.Create(OpCodes.Conv_I2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_I4"/>.
        /// </summary>
        public static Instruction Conv_I4()
            => Instruction.Create(OpCodes.Conv_I4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_I8"/>.
        /// </summary>
        public static Instruction Conv_I8()
            => Instruction.Create(OpCodes.Conv_I8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I"/>.
        /// </summary>
        public static Instruction Conv_Ovf_I()
            => Instruction.Create(OpCodes.Conv_Ovf_I);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I_Un"/>.
        /// </summary>
        public static Instruction Conv_Ovf_I_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_I_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I1"/>.
        /// </summary>
        public static Instruction Conv_Ovf_I1()
            => Instruction.Create(OpCodes.Conv_Ovf_I1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I1_Un"/>.
        /// </summary>
        public static Instruction Conv_Ovf_I1_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_I1_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I2"/>.
        /// </summary>
        public static Instruction Conv_Ovf_I2()
            => Instruction.Create(OpCodes.Conv_Ovf_I2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I2_Un"/>.
        /// </summary>
        public static Instruction Conv_Ovf_I2_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_I2_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I4"/>.
        /// </summary>
        public static Instruction Conv_Ovf_I4()
            => Instruction.Create(OpCodes.Conv_Ovf_I4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I4_Un"/>.
        /// </summary>
        public static Instruction Conv_Ovf_I4_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_I4_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I8"/>.
        /// </summary>
        public static Instruction Conv_Ovf_I8()
            => Instruction.Create(OpCodes.Conv_Ovf_I8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_I8_Un"/>.
        /// </summary>
        public static Instruction Conv_Ovf_I8_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_I8_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U"/>.
        /// </summary>
        public static Instruction Conv_Ovf_U()
            => Instruction.Create(OpCodes.Conv_Ovf_U);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U_Un"/>.
        /// </summary>
        public static Instruction Conv_Ovf_U_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_U_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U1"/>.
        /// </summary>
        public static Instruction Conv_Ovf_U1()
            => Instruction.Create(OpCodes.Conv_Ovf_U1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U1_Un"/>.
        /// </summary>
        public static Instruction Conv_Ovf_U1_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_U1_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U2"/>.
        /// </summary>
        public static Instruction Conv_Ovf_U2()
            => Instruction.Create(OpCodes.Conv_Ovf_U2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U2_Un"/>.
        /// </summary>
        public static Instruction Conv_Ovf_U2_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_U2_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U4"/>.
        /// </summary>
        public static Instruction Conv_Ovf_U4()
            => Instruction.Create(OpCodes.Conv_Ovf_U4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U4_Un"/>.
        /// </summary>
        public static Instruction Conv_Ovf_U4_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_U4_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U8"/>.
        /// </summary>
        public static Instruction Conv_Ovf_U8()
            => Instruction.Create(OpCodes.Conv_Ovf_U8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_Ovf_U8_Un"/>.
        /// </summary>
        public static Instruction Conv_Ovf_U8_Un()
            => Instruction.Create(OpCodes.Conv_Ovf_U8_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_R_Un"/>.
        /// </summary>
        public static Instruction Conv_R_Un()
            => Instruction.Create(OpCodes.Conv_R_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_R4"/>.
        /// </summary>
        public static Instruction Conv_R4()
            => Instruction.Create(OpCodes.Conv_R4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_R8"/>.
        /// </summary>
        public static Instruction Conv_R8()
            => Instruction.Create(OpCodes.Conv_R8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_U"/>.
        /// </summary>
        public static Instruction Conv_U()
            => Instruction.Create(OpCodes.Conv_U);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_U1"/>.
        /// </summary>
        public static Instruction Conv_U1()
            => Instruction.Create(OpCodes.Conv_U1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_U2"/>.
        /// </summary>
        public static Instruction Conv_U2()
            => Instruction.Create(OpCodes.Conv_U2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_U4"/>.
        /// </summary>
        public static Instruction Conv_U4()
            => Instruction.Create(OpCodes.Conv_U4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Conv_U8"/>.
        /// </summary>
        public static Instruction Conv_U8()
            => Instruction.Create(OpCodes.Conv_U8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Cpblk"/>.
        /// </summary>
        public static Instruction Cpblk()
            => Instruction.Create(OpCodes.Cpblk);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Div"/>.
        /// </summary>
        public static Instruction Div()
            => Instruction.Create(OpCodes.Div);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Div_Un"/>.
        /// </summary>
        public static Instruction Div_Un()
            => Instruction.Create(OpCodes.Div_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Dup"/>.
        /// </summary>
        public static Instruction Dup()
            => Instruction.Create(OpCodes.Dup);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Endfilter"/>.
        /// </summary>
        public static Instruction Endfilter()
            => Instruction.Create(OpCodes.Endfilter);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Endfinally"/>.
        /// </summary>
        public static Instruction Endfinally()
            => Instruction.Create(OpCodes.Endfinally);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Initblk"/>.
        /// </summary>
        public static Instruction Initblk()
            => Instruction.Create(OpCodes.Initblk);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldarg_0"/>.
        /// </summary>
        public static Instruction Ldarg_0()
            => Instruction.Create(OpCodes.Ldarg_0);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldarg_1"/>.
        /// </summary>
        public static Instruction Ldarg_1()
            => Instruction.Create(OpCodes.Ldarg_1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldarg_2"/>.
        /// </summary>
        public static Instruction Ldarg_2()
            => Instruction.Create(OpCodes.Ldarg_2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldarg_3"/>.
        /// </summary>
        public static Instruction Ldarg_3()
            => Instruction.Create(OpCodes.Ldarg_3);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_0"/>.
        /// </summary>
        public static Instruction Ldc_I4_0()
            => Instruction.Create(OpCodes.Ldc_I4_0);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_1"/>.
        /// </summary>
        public static Instruction Ldc_I4_1()
            => Instruction.Create(OpCodes.Ldc_I4_1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_2"/>.
        /// </summary>
        public static Instruction Ldc_I4_2()
            => Instruction.Create(OpCodes.Ldc_I4_2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_3"/>.
        /// </summary>
        public static Instruction Ldc_I4_3()
            => Instruction.Create(OpCodes.Ldc_I4_3);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_4"/>.
        /// </summary>
        public static Instruction Ldc_I4_4()
            => Instruction.Create(OpCodes.Ldc_I4_4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_5"/>.
        /// </summary>
        public static Instruction Ldc_I4_5()
            => Instruction.Create(OpCodes.Ldc_I4_5);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_6"/>.
        /// </summary>
        public static Instruction Ldc_I4_6()
            => Instruction.Create(OpCodes.Ldc_I4_6);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_7"/>.
        /// </summary>
        public static Instruction Ldc_I4_7()
            => Instruction.Create(OpCodes.Ldc_I4_7);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_8"/>.
        /// </summary>
        public static Instruction Ldc_I4_8()
            => Instruction.Create(OpCodes.Ldc_I4_8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_M1"/>.
        /// </summary>
        public static Instruction Ldc_I4_M1()
            => Instruction.Create(OpCodes.Ldc_I4_M1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_I"/>.
        /// </summary>
        public static Instruction Ldelem_I()
            => Instruction.Create(OpCodes.Ldelem_I);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_I1"/>.
        /// </summary>
        public static Instruction Ldelem_I1()
            => Instruction.Create(OpCodes.Ldelem_I1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_I2"/>.
        /// </summary>
        public static Instruction Ldelem_I2()
            => Instruction.Create(OpCodes.Ldelem_I2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_I4"/>.
        /// </summary>
        public static Instruction Ldelem_I4()
            => Instruction.Create(OpCodes.Ldelem_I4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_I8"/>.
        /// </summary>
        public static Instruction Ldelem_I8()
            => Instruction.Create(OpCodes.Ldelem_I8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_R4"/>.
        /// </summary>
        public static Instruction Ldelem_R4()
            => Instruction.Create(OpCodes.Ldelem_R4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_R8"/>.
        /// </summary>
        public static Instruction Ldelem_R8()
            => Instruction.Create(OpCodes.Ldelem_R8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_Ref"/>.
        /// </summary>
        public static Instruction Ldelem_Ref()
            => Instruction.Create(OpCodes.Ldelem_Ref);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_U1"/>.
        /// </summary>
        public static Instruction Ldelem_U1()
            => Instruction.Create(OpCodes.Ldelem_U1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_U2"/>.
        /// </summary>
        public static Instruction Ldelem_U2()
            => Instruction.Create(OpCodes.Ldelem_U2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelem_U4"/>.
        /// </summary>
        public static Instruction Ldelem_U4()
            => Instruction.Create(OpCodes.Ldelem_U4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_I"/>.
        /// </summary>
        public static Instruction Ldind_I()
            => Instruction.Create(OpCodes.Ldind_I);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_I1"/>.
        /// </summary>
        public static Instruction Ldind_I1()
            => Instruction.Create(OpCodes.Ldind_I1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_I2"/>.
        /// </summary>
        public static Instruction Ldind_I2()
            => Instruction.Create(OpCodes.Ldind_I2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_I4"/>.
        /// </summary>
        public static Instruction Ldind_I4()
            => Instruction.Create(OpCodes.Ldind_I4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_I8"/>.
        /// </summary>
        public static Instruction Ldind_I8()
            => Instruction.Create(OpCodes.Ldind_I8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_R4"/>.
        /// </summary>
        public static Instruction Ldind_R4()
            => Instruction.Create(OpCodes.Ldind_R4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_R8"/>.
        /// </summary>
        public static Instruction Ldind_R8()
            => Instruction.Create(OpCodes.Ldind_R8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_Ref"/>.
        /// </summary>
        public static Instruction Ldind_Ref()
            => Instruction.Create(OpCodes.Ldind_Ref);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_U1"/>.
        /// </summary>
        public static Instruction Ldind_U1()
            => Instruction.Create(OpCodes.Ldind_U1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_U2"/>.
        /// </summary>
        public static Instruction Ldind_U2()
            => Instruction.Create(OpCodes.Ldind_U2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldind_U4"/>.
        /// </summary>
        public static Instruction Ldind_U4()
            => Instruction.Create(OpCodes.Ldind_U4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldlen"/>.
        /// </summary>
        public static Instruction Ldlen()
            => Instruction.Create(OpCodes.Ldlen);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldloc_0"/>.
        /// </summary>
        public static Instruction Ldloc_0()
            => Instruction.Create(OpCodes.Ldloc_0);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldloc_1"/>.
        /// </summary>
        public static Instruction Ldloc_1()
            => Instruction.Create(OpCodes.Ldloc_1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldloc_2"/>.
        /// </summary>
        public static Instruction Ldloc_2()
            => Instruction.Create(OpCodes.Ldloc_2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldloc_3"/>.
        /// </summary>
        public static Instruction Ldloc_3()
            => Instruction.Create(OpCodes.Ldloc_3);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldnull"/>.
        /// </summary>
        public static Instruction Ldnull()
            => Instruction.Create(OpCodes.Ldnull);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Localloc"/>.
        /// </summary>
        public static Instruction Localloc()
            => Instruction.Create(OpCodes.Localloc);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Mul"/>.
        /// </summary>
        public static Instruction Mul()
            => Instruction.Create(OpCodes.Mul);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Mul_Ovf"/>.
        /// </summary>
        public static Instruction Mul_Ovf()
            => Instruction.Create(OpCodes.Mul_Ovf);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Mul_Ovf_Un"/>.
        /// </summary>
        public static Instruction Mul_Ovf_Un()
            => Instruction.Create(OpCodes.Mul_Ovf_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Neg"/>.
        /// </summary>
        public static Instruction Neg()
            => Instruction.Create(OpCodes.Neg);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Nop"/>.
        /// </summary>
        public static Instruction Nop()
            => Instruction.Create(OpCodes.Nop);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Not"/>.
        /// </summary>
        public static Instruction Not()
            => Instruction.Create(OpCodes.Not);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Or"/>.
        /// </summary>
        public static Instruction Or()
            => Instruction.Create(OpCodes.Or);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Pop"/>.
        /// </summary>
        public static Instruction Pop()
            => Instruction.Create(OpCodes.Pop);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Readonly"/>.
        /// </summary>
        public static Instruction Readonly()
            => Instruction.Create(OpCodes.Readonly);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Refanytype"/>.
        /// </summary>
        public static Instruction Refanytype()
            => Instruction.Create(OpCodes.Refanytype);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Rem"/>.
        /// </summary>
        public static Instruction Rem()
            => Instruction.Create(OpCodes.Rem);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Rem_Un"/>.
        /// </summary>
        public static Instruction Rem_Un()
            => Instruction.Create(OpCodes.Rem_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ret"/>.
        /// </summary>
        public static Instruction Ret()
            => Instruction.Create(OpCodes.Ret);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Rethrow"/>.
        /// </summary>
        public static Instruction Rethrow()
            => Instruction.Create(OpCodes.Rethrow);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Shl"/>.
        /// </summary>
        public static Instruction Shl()
            => Instruction.Create(OpCodes.Shl);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Shr"/>.
        /// </summary>
        public static Instruction Shr()
            => Instruction.Create(OpCodes.Shr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Shr_Un"/>.
        /// </summary>
        public static Instruction Shr_Un()
            => Instruction.Create(OpCodes.Shr_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_I"/>.
        /// </summary>
        public static Instruction Stelem_I()
            => Instruction.Create(OpCodes.Stelem_I);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_I1"/>.
        /// </summary>
        public static Instruction Stelem_I1()
            => Instruction.Create(OpCodes.Stelem_I1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_I2"/>.
        /// </summary>
        public static Instruction Stelem_I2()
            => Instruction.Create(OpCodes.Stelem_I2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_I4"/>.
        /// </summary>
        public static Instruction Stelem_I4()
            => Instruction.Create(OpCodes.Stelem_I4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_I8"/>.
        /// </summary>
        public static Instruction Stelem_I8()
            => Instruction.Create(OpCodes.Stelem_I8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_R4"/>.
        /// </summary>
        public static Instruction Stelem_R4()
            => Instruction.Create(OpCodes.Stelem_R4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_R8"/>.
        /// </summary>
        public static Instruction Stelem_R8()
            => Instruction.Create(OpCodes.Stelem_R8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stelem_Ref"/>.
        /// </summary>
        public static Instruction Stelem_Ref()
            => Instruction.Create(OpCodes.Stelem_Ref);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_I"/>.
        /// </summary>
        public static Instruction Stind_I()
            => Instruction.Create(OpCodes.Stind_I);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_I1"/>.
        /// </summary>
        public static Instruction Stind_I1()
            => Instruction.Create(OpCodes.Stind_I1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_I2"/>.
        /// </summary>
        public static Instruction Stind_I2()
            => Instruction.Create(OpCodes.Stind_I2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_I4"/>.
        /// </summary>
        public static Instruction Stind_I4()
            => Instruction.Create(OpCodes.Stind_I4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_I8"/>.
        /// </summary>
        public static Instruction Stind_I8()
            => Instruction.Create(OpCodes.Stind_I8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_R4"/>.
        /// </summary>
        public static Instruction Stind_R4()
            => Instruction.Create(OpCodes.Stind_R4);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_R8"/>.
        /// </summary>
        public static Instruction Stind_R8()
            => Instruction.Create(OpCodes.Stind_R8);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stind_Ref"/>.
        /// </summary>
        public static Instruction Stind_Ref()
            => Instruction.Create(OpCodes.Stind_Ref);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stloc_0"/>.
        /// </summary>
        public static Instruction Stloc_0()
            => Instruction.Create(OpCodes.Stloc_0);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stloc_1"/>.
        /// </summary>
        public static Instruction Stloc_1()
            => Instruction.Create(OpCodes.Stloc_1);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stloc_2"/>.
        /// </summary>
        public static Instruction Stloc_2()
            => Instruction.Create(OpCodes.Stloc_2);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stloc_3"/>.
        /// </summary>
        public static Instruction Stloc_3()
            => Instruction.Create(OpCodes.Stloc_3);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Sub"/>.
        /// </summary>
        public static Instruction Sub()
            => Instruction.Create(OpCodes.Sub);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Sub_Ovf"/>.
        /// </summary>
        public static Instruction Sub_Ovf()
            => Instruction.Create(OpCodes.Sub_Ovf);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Sub_Ovf_Un"/>.
        /// </summary>
        public static Instruction Sub_Ovf_Un()
            => Instruction.Create(OpCodes.Sub_Ovf_Un);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Tail"/>.
        /// </summary>
        public static Instruction Tail()
            => Instruction.Create(OpCodes.Tail);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Throw"/>.
        /// </summary>
        public static Instruction Throw()
            => Instruction.Create(OpCodes.Throw);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Volatile"/>.
        /// </summary>
        public static Instruction Volatile()
            => Instruction.Create(OpCodes.Volatile);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Xor"/>.
        /// </summary>
        public static Instruction Xor()
            => Instruction.Create(OpCodes.Xor);
                        #endregion // 
        
        #region int nbr
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Beq"/>.
        /// </summary>
        public static Instruction Beq(int nbr)
            => Instruction.Create(OpCodes.Beq, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bge"/>.
        /// </summary>
        public static Instruction Bge(int nbr)
            => Instruction.Create(OpCodes.Bge, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bge_Un"/>.
        /// </summary>
        public static Instruction Bge_Un(int nbr)
            => Instruction.Create(OpCodes.Bge_Un, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bgt"/>.
        /// </summary>
        public static Instruction Bgt(int nbr)
            => Instruction.Create(OpCodes.Bgt, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bgt_Un"/>.
        /// </summary>
        public static Instruction Bgt_Un(int nbr)
            => Instruction.Create(OpCodes.Bgt_Un, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ble"/>.
        /// </summary>
        public static Instruction Ble(int nbr)
            => Instruction.Create(OpCodes.Ble, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ble_Un"/>.
        /// </summary>
        public static Instruction Ble_Un(int nbr)
            => Instruction.Create(OpCodes.Ble_Un, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Blt"/>.
        /// </summary>
        public static Instruction Blt(int nbr)
            => Instruction.Create(OpCodes.Blt, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Blt_Un"/>.
        /// </summary>
        public static Instruction Blt_Un(int nbr)
            => Instruction.Create(OpCodes.Blt_Un, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bne_Un"/>.
        /// </summary>
        public static Instruction Bne_Un(int nbr)
            => Instruction.Create(OpCodes.Bne_Un, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Br"/>.
        /// </summary>
        public static Instruction Br(int nbr)
            => Instruction.Create(OpCodes.Br, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Brfalse"/>.
        /// </summary>
        public static Instruction Brfalse(int nbr)
            => Instruction.Create(OpCodes.Brfalse, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Brtrue"/>.
        /// </summary>
        public static Instruction Brtrue(int nbr)
            => Instruction.Create(OpCodes.Brtrue, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4"/>.
        /// </summary>
        public static Instruction Ldc_I4(int nbr)
            => Instruction.Create(OpCodes.Ldc_I4, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Leave"/>.
        /// </summary>
        public static Instruction Leave(int nbr)
            => Instruction.Create(OpCodes.Leave, nbr);
                        #endregion // int nbr
        
        #region sbyte nbr
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Beq_S"/>.
        /// </summary>
        public static Instruction Beq_S(sbyte nbr)
            => Instruction.Create(OpCodes.Beq_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bge_S"/>.
        /// </summary>
        public static Instruction Bge_S(sbyte nbr)
            => Instruction.Create(OpCodes.Bge_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bge_Un_S"/>.
        /// </summary>
        public static Instruction Bge_Un_S(sbyte nbr)
            => Instruction.Create(OpCodes.Bge_Un_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bgt_S"/>.
        /// </summary>
        public static Instruction Bgt_S(sbyte nbr)
            => Instruction.Create(OpCodes.Bgt_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bgt_Un_S"/>.
        /// </summary>
        public static Instruction Bgt_Un_S(sbyte nbr)
            => Instruction.Create(OpCodes.Bgt_Un_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ble_S"/>.
        /// </summary>
        public static Instruction Ble_S(sbyte nbr)
            => Instruction.Create(OpCodes.Ble_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ble_Un_S"/>.
        /// </summary>
        public static Instruction Ble_Un_S(sbyte nbr)
            => Instruction.Create(OpCodes.Ble_Un_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Blt_S"/>.
        /// </summary>
        public static Instruction Blt_S(sbyte nbr)
            => Instruction.Create(OpCodes.Blt_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Blt_Un_S"/>.
        /// </summary>
        public static Instruction Blt_Un_S(sbyte nbr)
            => Instruction.Create(OpCodes.Blt_Un_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Bne_Un_S"/>.
        /// </summary>
        public static Instruction Bne_Un_S(sbyte nbr)
            => Instruction.Create(OpCodes.Bne_Un_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Br_S"/>.
        /// </summary>
        public static Instruction Br_S(sbyte nbr)
            => Instruction.Create(OpCodes.Br_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Brfalse_S"/>.
        /// </summary>
        public static Instruction Brfalse_S(sbyte nbr)
            => Instruction.Create(OpCodes.Brfalse_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Brtrue_S"/>.
        /// </summary>
        public static Instruction Brtrue_S(sbyte nbr)
            => Instruction.Create(OpCodes.Brtrue_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I4_S"/>.
        /// </summary>
        public static Instruction Ldc_I4_S(sbyte nbr)
            => Instruction.Create(OpCodes.Ldc_I4_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Leave_S"/>.
        /// </summary>
        public static Instruction Leave_S(sbyte nbr)
            => Instruction.Create(OpCodes.Leave_S, nbr);
                        #endregion // sbyte nbr
        
        #region MethodReference method
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Call"/>.
        /// </summary>
        public static Instruction Call(MethodReference method)
            => Instruction.Create(OpCodes.Call, method);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Callvirt"/>.
        /// </summary>
        public static Instruction Callvirt(MethodReference method)
            => Instruction.Create(OpCodes.Callvirt, method);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Jmp"/>.
        /// </summary>
        public static Instruction Jmp(MethodReference method)
            => Instruction.Create(OpCodes.Jmp, method);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldftn"/>.
        /// </summary>
        public static Instruction Ldftn(MethodReference method)
            => Instruction.Create(OpCodes.Ldftn, method);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldvirtftn"/>.
        /// </summary>
        public static Instruction Ldvirtftn(MethodReference method)
            => Instruction.Create(OpCodes.Ldvirtftn, method);
                        #endregion // MethodReference method
        
        #region CallSite call
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Calli"/>.
        /// </summary>
        public static Instruction Calli(CallSite call)
            => Instruction.Create(OpCodes.Calli, call);
                        #endregion // CallSite call
        
        #region TypeReference type
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Castclass"/>.
        /// </summary>
        public static Instruction Castclass(TypeReference type)
            => Instruction.Create(OpCodes.Castclass, type);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Isinst"/>.
        /// </summary>
        public static Instruction Isinst(TypeReference type)
            => Instruction.Create(OpCodes.Isinst, type);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldelema"/>.
        /// </summary>
        public static Instruction Ldelema(TypeReference type)
            => Instruction.Create(OpCodes.Ldelema, type);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Mkrefany"/>.
        /// </summary>
        public static Instruction Mkrefany(TypeReference type)
            => Instruction.Create(OpCodes.Mkrefany, type);
                        #endregion // TypeReference type
        
        #region byte nbr
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldarg_S"/>.
        /// </summary>
        public static Instruction Ldarg_S(byte nbr)
            => Instruction.Create(OpCodes.Ldarg_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldarga_S"/>.
        /// </summary>
        public static Instruction Ldarga_S(byte nbr)
            => Instruction.Create(OpCodes.Ldarga_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldloc_S"/>.
        /// </summary>
        public static Instruction Ldloc_S(byte nbr)
            => Instruction.Create(OpCodes.Ldloc_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldloca_S"/>.
        /// </summary>
        public static Instruction Ldloca_S(byte nbr)
            => Instruction.Create(OpCodes.Ldloca_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Starg_S"/>.
        /// </summary>
        public static Instruction Starg_S(byte nbr)
            => Instruction.Create(OpCodes.Starg_S, nbr);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stloc_S"/>.
        /// </summary>
        public static Instruction Stloc_S(byte nbr)
            => Instruction.Create(OpCodes.Stloc_S, nbr);
                        #endregion // byte nbr
        
        #region long nbr
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_I8"/>.
        /// </summary>
        public static Instruction Ldc_I8(long nbr)
            => Instruction.Create(OpCodes.Ldc_I8, nbr);
                        #endregion // long nbr
        
        #region float nbr
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_R4"/>.
        /// </summary>
        public static Instruction Ldc_R4(float nbr)
            => Instruction.Create(OpCodes.Ldc_R4, nbr);
                        #endregion // float nbr
        
        #region double nbr
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldc_R8"/>.
        /// </summary>
        public static Instruction Ldc_R8(double nbr)
            => Instruction.Create(OpCodes.Ldc_R8, nbr);
                        #endregion // double nbr
        
        #region string str
            
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldfld"/>.
        /// </summary>
        public static Instruction Ldfld(string str)
            => Instruction.Create(OpCodes.Ldfld, str);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldflda"/>.
        /// </summary>
        public static Instruction Ldflda(string str)
            => Instruction.Create(OpCodes.Ldflda, str);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldsfld"/>.
        /// </summary>
        public static Instruction Ldsfld(string str)
            => Instruction.Create(OpCodes.Ldsfld, str);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Ldsflda"/>.
        /// </summary>
        public static Instruction Ldsflda(string str)
            => Instruction.Create(OpCodes.Ldsflda, str);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stfld"/>.
        /// </summary>
        public static Instruction Stfld(string str)
            => Instruction.Create(OpCodes.Stfld, str);
                
        /// <summary>
        /// Create a new <see cref="Instruction"/> which emits
        /// <see cref="OpCodes.Stsfld"/>.
        /// </summary>
        public static Instruction Stsfld(string str)
            => Instruction.Create(OpCodes.Stsfld, str);
                        #endregion // string str
        
    }
}