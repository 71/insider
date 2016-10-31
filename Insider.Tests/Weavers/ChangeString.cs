using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Insider.Tests
{
    /// <summary>
    /// Changes the first constant string to be declared
    /// to "I have been modified."
    /// </summary>
    public sealed class ChangeStringAttribute : WeaverAttribute, IMethodWeaver
    {
        public void Apply(MethodDefinition method)
        {
            Log($"Modifying {method.FullName}", MessageImportance.Info);

            for (int i = 0; i < method.Body.Instructions.Count; i++)
            {
                var instr = method.Body.Instructions[i];
                if (instr.OpCode == OpCodes.Ldstr)
                {
                    instr.Operand = "I have been modified.";
                    break;
                }
            }
        }
    }
}
