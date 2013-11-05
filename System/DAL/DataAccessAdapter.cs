using Contracts.Dal;
using FluentNHibernate.Cfg;

namespace DAL
{
    public sealed class DataAccessAdapter : IDataAccessAdapter
    {
        private readonly FluentConfiguration _configuration;

        public DataAccessAdapter()
        {
            _configuration = FluentEnvironment.GetConfiguration();
        }

        public IDataAccessSession GetSession()
        {
            return new DataAccessSession(_configuration);
        }
    }
}
