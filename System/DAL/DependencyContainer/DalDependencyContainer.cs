using DAL.Adapters;
using Ninject.Modules;

namespace DAL.DependencyContainer
{
    public class DalDependencyContainer : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataLayerAdapter>().To<DataLayerAdapter>().InTransientScope();
        }
    }
}
