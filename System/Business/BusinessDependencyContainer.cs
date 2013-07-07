using Business.Contracts;
using Business.Services.Authentication;
using Business.Services.Objects;
using Ninject.Modules;

namespace Business
{
    public class BusinessDependencyContainer : NinjectModule
    {
        public override void Load()
        {
            Bind<IObjectService>().To<ObjectService>().InTransientScope();
            Bind<IAuthenticationService>().To<AuthenticationService>().InTransientScope();
        }
    }
}
