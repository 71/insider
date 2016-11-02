using System;
using System.IO;
using SR = System.Reflection;

namespace Insider
{
    public sealed class Outsider : IDisposable
    {
        public readonly Weaver Weaver;
        public readonly AppDomain Domain;

        public Outsider(string filepath, string targetpath, params string[] referencedFiles)
        {
            AppDomainSetup domainSetup = new AppDomainSetup
            {
                PrivateBinPath = filepath,
                ApplicationBase = Path.GetDirectoryName(typeof(Weaver).Assembly.Location)
            };
            Domain = AppDomain.CreateDomain("Insider's Weaving domain", null, domainSetup);

            Weaver = RemotelyCreate<Weaver>(Domain, filepath, targetpath, referencedFiles);

            Domain.SetupInformation.ApplicationBase = Path.GetDirectoryName(filepath);
        }

        private static T RemotelyCreate<T>(AppDomain domain, params object[] ctorParameters)
        {
            return (T)domain.CreateInstanceFromAndUnwrap(
                typeof(T).Assembly.Location, typeof(T).FullName, false,
                SR.BindingFlags.CreateInstance, null,
                ctorParameters, null, null);
        }

        public void Dispose()
        {
            Weaver.Dispose();
            AppDomain.Unload(Domain);
        }
    }
}
