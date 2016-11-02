using Shouldly;
using Insider;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;

[assembly: Setting("Foo", "Bar")]

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
            Log("Hello world", MessageImportance.Debug);

            foreach (var instr in method.Body.Instructions)
            {
                if (instr.OpCode == From)
                    instr.OpCode = To;
            }
        }
    }

    class EnvironmentTestAttribute : WeaverAttribute, ITypeWeaver
    {
        public void Apply(TypeDefinition type)
        {
            Settings.ContainsKey("Foo").ShouldBeTrue();
            Settings["Foo"].ShouldBe("Bar");

            Settings.ContainsKey("Insider.CleanUp").ShouldBeTrue();
            Settings["Insider.CleanUp"].ShouldBe(true);
        }
    }

    [EnvironmentTest]
    class Program
    {
        static extern void MakeTests();

        static int Main(string[] args)
        {
            try
            {
                MakeTests();
                Console.WriteLine("All tests passed successfully.");
#if DEBUG
                Console.ReadKey(true);
#endif
                return 0;
            }
            catch (ShouldAssertException e)
            {
                Console.Error.WriteLine(e.Message);
#if DEBUG
                Console.ReadKey(true);
#endif
                return 1;
            }
        }

        [Test("The insider will convert all 1's to 2's")]
        [OpCodeReplacer(Code.Ldc_I4_1, Code.Ldc_I4_2)]
        static void ChangeInt()
        {
            (int.Parse("1") + 1).ShouldNotBe(2);
        }

        [Test("The insider will change the first string to 'I have been modified'")]
        [ChangeString]
        static void ChangeString()
        {
            "I haven't been modified.".ShouldBe("I have been modified.");
        }
    }
}
