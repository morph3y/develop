using Business.Contracts;
using Business.Services.Objects;
using Business.Services.UserAccess;
using Business.UserAccess;
using Ninject.Modules;

namespace Business
{
    public class BusinessDependencyContainer : NinjectModule
    {
        public override void Load()
        {
            Bind<IObjectService>().To<ObjectService>().InTransientScope();
            Bind<IAuthentication>().To<Authentication>().InTransientScope();
            Bind<IUserAccessManager>().To<UserAccessManager>().InThreadScope();
        }
    }
}
