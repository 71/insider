using System;
using System.IO;
using SR = System.Reflection;

namespace Insider
{
    public sealed partial class Weaver
    {
        /// <summary>
        /// Create a new <see cref="AppDomain"/> in which a <see cref="Weaver"/>
        /// will be created, and return the latter.
        /// </summary>
        public static Weaver Create(string filepath, string targetpath, params string[] referencedFiles)
        {
            try
            {
                AppDomainSetup domainSetup = new AppDomainSetup
                {
                    PrivateBinPath = filepath,
                    ApplicationBase = Path.GetDirectoryName(typeof(Weaver).Assembly.Location)
                };
                AppDomain domain = AppDomain.CreateDomain("Insider's Weaving domain", null, domainSetup);

                Weaver weaver = RemotelyCreate<Weaver>(domain, filepath, targetpath, referencedFiles);

                domain.SetupInformation.ApplicationBase = Path.GetDirectoryName(filepath);

                return weaver;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private static T RemotelyCreate<T>(AppDomain domain, params object[] ctorParameters)
        {
            return (T)domain.CreateInstanceFromAndUnwrap(
                typeof(T).Assembly.Location, typeof(T).FullName, false,
                SR.BindingFlags.CreateInstance, null,
                ctorParameters, null, null);
        }
    }
}
