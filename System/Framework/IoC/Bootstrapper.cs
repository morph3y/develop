using Business;
using DAL;
using StructureMap;

namespace Framework.IoC
{
    public class Bootstrapper
    {
        private static bool _hasStarted;
        public void BootstrapStructureMap()
        {
            ObjectFactory.Configure(x=>
            {
                x.IncludeRegistry(new DalContainerRegistry());
                x.IncludeRegistry(new BusinessContainerRegistry());
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