using Business;
using DAL;
using Framework.Common.IoC;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Framework.IoC
{
    public class Bootstrapper
    {
        private static bool _hasStarted;
        public void BootstrapStructureMap()
        {
            ObjectFactory.Configure(x => x.For<IContainerRegistry>().Use<ContainerRegistry>());
            ObjectFactory.Configure(x =>
            {
                x.IncludeRegistry(new DalContainerRegistry().Registry as Registry);
                x.IncludeRegistry(new BusinessContainerRegistry().Registry as Registry);
            });
        }

        public static void Restart()
        {
            if (_hasStarted)
            {
                ObjectFactory.ResetDefaults();
            }
            else
            {
                Bootstrap();
                _hasStarted = true;
            }
        }

        public static void Bootstrap()
        {
            new Bootstrapper().BootstrapStructureMap();
        }
    }
}