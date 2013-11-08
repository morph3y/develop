using Business.Services;
using Contracts.Business;
using StructureMap.Configuration.DSL;

namespace Business
{
    public sealed class BusinessContainerRegistry : Registry
    {
        public BusinessContainerRegistry()
        {
            For<IObjectService>().Use<ObjectService>();
        }
    }
}
