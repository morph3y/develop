using System.Reflection;
using StructureMap.Configuration.DSL;

namespace Framework
{
    internal sealed class FrameworkContainerRegistry : Registry
    {
        public FrameworkContainerRegistry()
        {
            Scan(x=>
            {
                x.TheCallingAssembly();
                x.Assembly(Assembly.Load("DAL"));
                x.Assembly(Assembly.Load("Contracts"));
                x.WithDefaultConventions();
                x.LookForRegistries();
            });
        }
    }
}
