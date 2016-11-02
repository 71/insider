using System;
using System.Linq;
using Mono.Cecil;
using SR = System.Reflection;

namespace Insider
{
    public sealed partial class Weaver : IDisposable
    {
        /// <summary>
        /// Trigger <see cref="MessageLogged"/>, and stop weaving if
        /// <paramref name="importance"/> is <see cref="MessageImportance.Error"/>.
        /// </summary>
        private void LogMessage(object sender, string msg, MessageImportance importance)
        {
            bool willThrow = importance == MessageImportance.Error
                || (importance == MessageImportance.Warning && TreatWarningsAsErrors);

            MessageLogged?.Invoke(new MessageLoggedEventArgs(msg, importance, willThrow, BeingProcessed, sender.GetType()));

            if (willThrow)
                throw new WeavingException(msg, BeingProcessed, sender.GetType());
        }

        /// <summary>
        /// Returns whether or not <paramref name="typeDef"/> is derived
        /// from <typeparamref name="T"/>.
        /// </summary>
        private bool Extends<T>(TypeDefinition typeDef)
        {
            if (typeDef == null)
                return false;

            if (typeof(T).IsInterface)
            {
                if (typeDef.Interfaces.Any(x => x.InterfaceType.Is(typeof(T))))
                    return true;

                return typeDef.BaseType != null
                    && Extends<T>(typeDef.BaseType.AsTypeDefinition());
            }
            else
            {
                return typeDef.BaseType != null
                    && (typeDef.BaseType.Is(typeof(T)) || Extends<T>(typeDef.BaseType.AsTypeDefinition()));
            }
        }

        /// <summary>
        /// Get the setting named <paramref name="key"/>, cast
        /// it to <typeparamref name="T"/> if possible,
        /// and return it.
        /// <para>
        /// If any of the above steps fails, <paramref name="defaultValue"/>
        /// will be returned.
        /// </para>
        /// </summary>
        private T GetSetting<T>(string key, T defaultValue = default(T))
        {
            object value;
            if (Settings.TryGetValue(key, out value) && value is T)
                return (T)value;
            return defaultValue;
        }
    }
}
