using Business.Services.Authentication;
using Business.Services.Objects;
using DAL;
using Framework.Common.Contracts;
using StructureMap;

namespace Framework
{
    public static class DependencyResolver
    {
        public static void Initialize(ConfigurationExpression conf)
        {
            conf.For<IObjectService>().Use<ObjectService>();
            conf.For<IDataLayerAdapter>().Use<DataLayerAdapter>();
            conf.For<IAuthenticationService>().Use<AuthenticationService>();
        }
    }
}
