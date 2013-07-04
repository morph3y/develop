using DAL.Contracts;
using Ninject.Modules;

namespace DAL
{
    public class DalDependencyContainer : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataLayerAdapter>().To<DataLayerAdapter>().InTransientScope();
        }
    }
}
