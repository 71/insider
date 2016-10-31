using System;
using Shouldly;
using Insider;
using Mono.Cecil;
using Mono.Cecil.Cil;

[assembly: Setting("Hello", "World")]
[assembly: Insider(CleanUp = false)]

namespace Insider.Tests
{
    class OneToTwoAttribute : WeaverAttribute, IMethodWeaver
    {
        public void Apply(MethodDefinition method)
        {
            foreach (var instr in method.Body.Instructions)
            {
                if (instr.OpCode == OpCodes.Ldc_I4 && instr.Operand.Equals(1))
                    instr.Operand = 2;
                else if (instr.OpCode == OpCodes.Ldc_I4_1)
                    instr.OpCode = OpCodes.Ldc_I4_2;
            }
        }
    }

    class OpCodeReplacerAttribute : WeaverAttribute, IMethodWeaver
    {
        public OpCode From { get; protected set; }
        public OpCode To { get; protected set; }

        public OpCodeReplacerAttribute(Code from, Code to)
        {
            From = (OpCode)typeof(OpCodes).GetField(from.ToString()).GetValue(null);
            To = (OpCode)typeof(OpCodes).GetField(to.ToString()).GetValue(null);
        }

        public void Apply(MethodDefinition method)
        {
            foreach (var instr in method.Body.Instructions)
            {
                if (instr.OpCode == From)
                    instr.OpCode = To;
            }
        }
    }

    class Program
    {
        [OpCodeReplacer(Code.Ldc_I4_1, Code.Ldc_I4_2)]
        [OneToTwo]
        static void Main(string[] args)
        {
            int result = int.Parse("1") + 1;
            if (result != 2)
                Console.Error.WriteLine("1+1 equals " + result + ", duh.");
            else
                Console.WriteLine("So apparently, 1+1 does equal 2.");
        }

        [ChangeString]
        static void ChangeString()
        {
            "I haven't been modified.".ShouldBe("I have been modified.");
        }
    }
}
