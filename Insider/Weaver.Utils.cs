using System;
using System.Linq;
using Mono.Cecil;

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

            MessageLogged?.Invoke(sender, new MessageLoggedEventArgs(msg, importance, willThrow));
            
            if (willThrow)
                throw new WeavingException(sender, msg, importance);
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
                    && Extends<T>(GetTypeDefinition(typeDef.BaseType));
            }
            else
            {
                return typeDef.BaseType != null
                    && (typeDef.BaseType.Is(typeof(T)) || Extends<T>(GetTypeDefinition(typeDef.BaseType)));
            }
        }


        // The following methods are less advanced than Weave.GetType*(),
        // but they're enough for the Weaver. I'm thus keeping them for a
        // small performance gain.


        private Type GetType(TypeReference typeRef)
        {
            if (Assemblies.ContainsKey(typeRef.Scope.Name))
                return Assemblies[typeRef.Scope.Name].Item1.GetType(typeRef.FullName);

            return Assembly.GetType(typeRef.FullName);
        }

        private TypeDefinition GetTypeDefinition(TypeReference typeRef)
        {
            if (Assemblies.ContainsKey(typeRef.Scope.Name))
                return Assemblies[typeRef.Scope.Name].Item2.MainModule.GetType(typeRef.FullName);

            return Module.GetType(typeRef.FullName);
        }

        private TypeDefinition GetType(Type type)
        {
            if (Assemblies.ContainsKey(type.Assembly.GetName().Name))
                return Assemblies[type.Module.Assembly.GetName().Name].Item2.MainModule.GetType(type.FullName);

            return Module.GetType(type.FullName);
        }
    }
}
