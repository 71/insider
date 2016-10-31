using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;

namespace Insider
{
    public sealed partial class Weaver
    {


        sealed class AssemblyResolver : IAssemblyResolver
        {
            public readonly Weaver Creator;

            public AssemblyResolver(Weaver creator)
            {
                Creator = creator;
            }

            public AssemblyDefinition Resolve(string fullName)
            {
                return Resolve(fullName, new ReaderParameters());
            }

            public AssemblyDefinition Resolve(AssemblyNameReference name)
            {
                return Resolve(name, new ReaderParameters());
            }

            public AssemblyDefinition Resolve(string fullName, ReaderParameters parameters)
            {
                var name = new System.Reflection.AssemblyName(fullName);

                if (Creator.Assemblies.ContainsKey(name.Name))
                    return Creator.Assemblies[name.Name].Item2;

                return null;
            }

            public AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters)
            {
                if (Creator.Assemblies.ContainsKey(name.Name))
                    return Creator.Assemblies[name.Name].Item2;

                return null;
            }

            public void Dispose()
            {

            }
        }
    }
}
