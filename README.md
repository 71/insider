# Insider
Insider uses [MSBuild](https://github.com/Microsoft/msbuild) and [Mono.Cecil](https://github.com/jbevain/cecil) to weave assemblies (although the former is optional).  
Unlike other programs that do the same thing, however, Insider changes things from the _inside_.

# Warning
Insider has been superseded by [Cometary](https://github.com/6A/Cometary), please check it out instead.

-------

# Old documentation

## One-minute guide
```csharp
using System;
using Insider;
using Mono.Cecil;
using Mono.Cecil.Cil;

/// <summary>
/// Forces all calls to ldc.i4 to load 2
/// instead of 1.
/// </summary>
class OneToTwoAttribute : MethodWeaverAttribute
{
	public override void Apply(MethodDefinition method)
    {
    	foreach (var instr in method.Body.Instructions)
        {
            if (instr.OpCode == OpCodes.Ldc_I4 && instr.Operand.Equals(1))
                instr.Operand = 2;
        }
    }
}

class Program
{
	[OneToTwo]
    static void Main(string[] args)
    {
    	int result = 1 + 1;
    	if (result == 2)
        	Console.Error.WriteLine("1+1 equals " + result + ", duh.");
    }
}
```

## How to install
#### `Install-Package Insider`
Currently compatible and tested on .NET 4.6 and above.



