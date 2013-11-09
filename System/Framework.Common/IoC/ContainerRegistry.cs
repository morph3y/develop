using StructureMap.Configuration.DSL;

namespace Framework.Common.IoC
{
    public class ContainerRegistry : Registry, IContainerRegistry
    {
        public void Map<TInterface, TConcrete>() where TConcrete : TInterface
        {
            For<TInterface>().Use<TConcrete>();
        }
    }
}
