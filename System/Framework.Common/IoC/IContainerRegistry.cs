namespace Framework.Common.IoC
{
    public interface IContainerRegistry
    {
        void Map<TInterface, TConcrete>() where TConcrete : TInterface;
    }
}