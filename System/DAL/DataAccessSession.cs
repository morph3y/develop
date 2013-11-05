using Contracts.Dal;
using FluentNHibernate.Cfg;
using NHibernate;

namespace DAL
{
    public sealed class DataAccessSession : IDataAccessSession
    {
        private readonly ISession _sessionFactory;

        public DataAccessSession()
            : this(FluentEnvironment.GetConfiguration())
        { }

        public DataAccessSession(FluentConfiguration configuration)
        {
            _sessionFactory = configuration.BuildSessionFactory().OpenSession();
        }

        public object Get<T>(int id)
        {
            return _sessionFactory.Get<T>(id);
        }

        public void Save<T>(T entity)
        {
            _sessionFactory.SaveOrUpdate(entity);
        }
    }
}
