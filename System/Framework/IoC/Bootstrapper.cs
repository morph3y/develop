using StructureMap;

namespace Framework.IoC
{
    public class Bootstrapper
    {
        private static bool _hasStarted;
        public void BootstrapStructureMap()
        {
            ObjectFactory.Configure(x=> x.AddRegistry(new FrameworkContainerRegistry()));
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