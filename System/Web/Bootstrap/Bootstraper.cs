using Framework;
using StructureMap;

namespace Web.Bootstrap
{
    public static class Bootstraper
    {
        public static void Initialize()
        {
            ObjectFactory.Configure(DependencyResolver.Initialize);
        }
    }
}