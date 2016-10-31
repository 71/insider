using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Insider.Tests
{
    /// <summary>
    /// Defines a static method that will be automatically ran
    /// when Program.MakeTests() is called.
    /// </summary>
    public class TestAttribute : WeaverAttribute, IMethodWeaver
    {
        public object[] Arguments { get; protected set; }
        public string Name { get; protected set; }

        public TestAttribute(string name, params object[] args)
        {
            Name = name;
            Arguments = args;
        }

        public void Apply(MethodDefinition method)
        {
            var entry = Weave.CurrentAssemblyDef
                .MainModule
                .GetType("Insider.Tests", "Program")
                .FindMethod("MakeTests");

            bool hadBody = entry.RVA != 0;
            
            entry.Body.EmitAtStart(
                GetArgumentLoadInstructions(IL.Call(method))
            );

            if (!hadBody)
                entry.Body.EmitAtEnd(IL.Ret());
        }

        private IEnumerable<Instruction> GetArgumentLoadInstructions(params Instruction[] after)
        {
            foreach (object arg in Arguments)
            {
                if (arg is string)
                    yield return IL.Ldstr((string)arg);
                else if (arg is int)
                    yield return IL.Ldc_I4((int)arg);
                else if (arg is long)
                    yield return IL.Ldc_I8((long)arg);
                else if (arg is float)
                    yield return IL.Ldc_R4((float)arg);
                else if (arg is double)
                    yield return IL.Ldc_R8((double)arg);
                else if (arg is bool)
                    yield return (bool)arg ? IL.Ldc_I4_1() : IL.Ldc_I4_0();
                else if (arg is byte)
                    yield return IL.Ldc_I4((byte)arg);
                else
                    throw new ArgumentException("Arguments must be string, int, long, float, double, bool or byte.");
            }

            foreach (Instruction ins in after)
                yield return ins;
        }
    }
}
