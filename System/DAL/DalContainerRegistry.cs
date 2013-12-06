using Contracts.Dal;
using Framework.Common;
using Framework.Common.IoC;

namespace DAL
{
    public sealed class DalContainerRegistry
    {
        private IContainerRegistry _registry;
        public IContainerRegistry Registry
        {
            get { return _registry ?? (_registry = ApplicationEnvironment.Resolve<IContainerRegistry>()); }
        }

        public DalContainerRegistry()
        {
            Registry.Map<IDataAccessAdapter, DataAccessAdapter>();
            Registry.Map<IUserAccessAdapter, DataAccessAdapter>();
        }
    }
}
