using Business.Services;
using Contracts.Business;
using Framework.Common;
using Framework.Common.IoC;

namespace Business
{
    public sealed class BusinessContainerRegistry
    {
        private IContainerRegistry _registry;
        public IContainerRegistry Registry
        {
            get { return _registry ?? (_registry = ApplicationEnvironment.Resolve<IContainerRegistry>()); }
        }

        public BusinessContainerRegistry()
        {
            Registry.Map<IObjectService, ObjectService>();
            Registry.Map<IUserService, UserService>();
        }
    }
}
