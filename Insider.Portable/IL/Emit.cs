using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil.Cil;

namespace Insider
{
    public static partial class IL
    {
        /// <summary>
        /// Insert a collection of <see cref="Instruction"/>s into the given
        /// <paramref name="body"/>, starting at <paramref name="index"/>.
        /// </summary>
        public static void Emit(this MethodBody body, int index, IEnumerable<Instruction> instructions)
            => Emit(body, index, instructions.ToArray());

        /// <summary>
        /// Insert an array of <see cref="Instruction"/>s into the given
        /// <paramref name="body"/>, starting at <paramref name="index"/>.
        /// </summary>
        public static void Emit(this MethodBody body, int index, params Instruction[] instructions)
        {
            if (body.Instructions.Count < index)
                throw new ArgumentOutOfRangeException(nameof(index));

            for (int i = 0; i < instructions.Length; i++)
                body.Instructions.Insert(i + index, instructions[i]);
        }


        /// <summary>
        /// Append a collection of <see cref="Instruction"/>s at the end of
        /// the given <paramref name="body"/>.
        /// </summary>
        public static void EmitAtEnd(this MethodBody body, IEnumerable<Instruction> instructions)
            => EmitAtEnd(body, instructions.ToArray());

        /// <summary>
        /// Append an array of <see cref="Instruction"/>s at the end of
        /// the given <paramref name="body"/>.
        /// </summary>
        public static void EmitAtEnd(this MethodBody body, params Instruction[] instructions)
        {
            for (int i = 0; i < instructions.Length; i++)
                body.Instructions.Add(instructions[i]);
        }

        /// <summary>
        /// Insert a collection of <see cref="Instruction"/>s at the start of
        /// the given <paramref name="body"/>.
        /// </summary>
        public static void EmitAtStart(this MethodBody body, IEnumerable<Instruction> instructions)
            => EmitAtStart(body, instructions.ToArray());

        /// <summary>
        /// Insert an array of <see cref="Instruction"/>s at the start of
        /// the given <paramref name="body"/>.
        /// </summary>
        public static void EmitAtStart(this MethodBody body, params Instruction[] instructions)
        {
            for (int i = 0; i < instructions.Length; i++)
                body.Instructions.Insert(i, instructions[i]);
        }


        /// <summary>
        /// Replace the <see cref="Instruction"/> at <paramref name="index" />
        /// by a collection of <see cref="Instruction"/>s.
        /// </summary>
        public static void Replace(this MethodBody body, int index, IEnumerable<Instruction> instructions)
            => Replace(body, index, 1, instructions.ToArray());

        /// <summary>
        /// Replace the <see cref="Instruction"/> at <paramref name="index" />
        /// by an array of <see cref="Instruction"/>s.
        /// </summary>
        public static void Replace(this MethodBody body, int index, params Instruction[] instructions)
            => Replace(body, index, 1, instructions);

        /// <summary>
        /// Replace the <see cref="Instruction"/>s starting at <paramref name="index"/>,
        /// up to (<paramref name="index"/> + <paramref name="length"/>)
        /// by a collection of <see cref="Instruction"/>s.
        /// </summary>
        public static void Replace(this MethodBody body, int index, int length, IEnumerable<Instruction> instructions)
            => Replace(body, index, length, instructions);

        /// <summary>
        /// Replace the <see cref="Instruction"/>s starting at <paramref name="index"/>,
        /// up to (<paramref name="index"/> + <paramref name="length"/>)
        /// by an array of <see cref="Instruction"/>s.
        /// </summary>
        public static void Replace(this MethodBody body, int index, int length, params Instruction[] instructions)
        {
            if (body.Instructions.Count < index + length || index < 0 || length < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            for (int i = 0; i < length; i++)
                body.Instructions.RemoveAt(index + i);
            for (int i = 0; i < instructions.Length; i++)
                body.Instructions.Insert(i + index, instructions[i]);
        }
    }
}
