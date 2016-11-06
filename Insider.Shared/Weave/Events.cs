using System;
using Mono.Cecil;

namespace Insider
{
    public static partial class Weave
    {
        /// <summary>
        /// Event triggered when a <see cref="TypeDefinition"/> has been scanned.
        /// </summary>
        public static event Action<TypeDefinition> TypeScanned;
        /// <summary>
        /// Event triggered when a <see cref="MethodDefinition"/> has been scanned.
        /// </summary>
        public static event Action<MethodDefinition> MethodScanned;
        /// <summary>
        /// Event triggered when a <see cref="PropertyDefinition"/> has been scanned.
        /// </summary>
        public static event Action<PropertyDefinition> PropertyScanned;
        /// <summary>
        /// Event triggered when a <see cref="FieldDefinition"/> has been scanned.
        /// </summary>
        public static event Action<FieldDefinition> FieldScanned;
        /// <summary>
        /// Event triggered when an <see cref="EventDefinition"/> has been scanned.
        /// </summary>
        public static event Action<EventDefinition> EventScanned;
        /// <summary>
        /// Event triggered when an <see cref="AssemblyDefinition"/> has been scanned.
        /// </summary>
        public static event Action<AssemblyDefinition> AssemblyScanned;
        /// <summary>
        /// Event triggered when a <see cref="ParameterDefinition"/> has been scanned.
        /// </summary>
        public static event Action<MethodDefinition, ParameterDefinition> ParameterScanned;

        internal static void TriggerScan(TypeDefinition def)
            => TypeScanned?.Invoke(def);
        internal static void TriggerScan(MethodDefinition def)
            => MethodScanned?.Invoke(def);
        internal static void TriggerScan(PropertyDefinition def)
            => PropertyScanned?.Invoke(def);
        internal static void TriggerScan(FieldDefinition def)
            => FieldScanned?.Invoke(def);
        internal static void TriggerScan(EventDefinition def)
            => EventScanned?.Invoke(def);
        internal static void TriggerScan(AssemblyDefinition def)
            => AssemblyScanned?.Invoke(def);
        internal static void TriggerScan(ParameterDefinition def, MethodDefinition m)
            => ParameterScanned?.Invoke(m, def);
    }
}
