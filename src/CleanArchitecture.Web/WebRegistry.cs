using CleanArchitecture.Core.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Web
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.AssemblyContainingType(typeof(IRepository<>)); // Core
                    scan.Assembly("CleanArchitecture.Infrastructure"); // the Infrastructure DLL
                    scan.WithDefaultConventions();
                    scan.ConnectImplementationsToTypesClosing(typeof(IHandle<>));
                    scan.LookForRegistries(); // find and run other registries
                });
        }
    }
}
