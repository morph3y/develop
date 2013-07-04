using Business.Contracts;
using Ninject.Modules;

namespace Business.DependencyContainer
{
    public class BusinessDependencyContainer : NinjectModule
    {
        public override void Load()
        {
            Bind<IObjectService>().To<ObjectService>().InTransientScope();
        }
    }
}
