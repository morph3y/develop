using Contracts.Dal;
using StructureMap.Configuration.DSL;

namespace DAL
{
    public sealed class DalContainerRegistry : Registry
    {
        public DalContainerRegistry()
        {
            For<IDataAccessAdapter>().Use<DataAccessAdapter>();
        }
    }
}
