using Shouldly;
using Insider;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;

[assembly: Setting("Hello", "World")]
[assembly: Insider(CleanUp = false)]

namespace Insider.Tests
{
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
        static extern void MakeTests();

        static int Main(string[] args)
        {
            try
            {
                MakeTests();
                Console.WriteLine("All tests passed successfully.");
                return 0;
            }
            catch (ShouldAssertException e)
            {
                Console.Error.WriteLine(e.Message);
                return 1;
            }
        }

        [Test("The insider will convert all 1's to 2's")]
        [OpCodeReplacer(Code.Ldc_I4_1, Code.Ldc_I4_2)]
        static void ChangeInt()
        {
            (int.Parse("1") + 1).ShouldNotBe(2);
        }

        [Test("The insider will change the first string to another one")]
        [ChangeString]
        static void ChangeString()
        {
            "I haven't been modified.".ShouldBe("I have been modified.");
        }
    }
}
