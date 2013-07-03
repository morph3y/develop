using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace DAL
{
    public static class DataAccessAdapter
    {
        private static ISessionFactory _sessionFactory;
        public static ISessionFactory Adapter
        {
            get
            {
                if (_sessionFactory == null)
                {
                    return _sessionFactory =
                           Fluently.Configure()
                               .Database(MsSqlConfiguration.MsSql2008.ConnectionString(
                                   cs => cs.FromConnectionStringWithKey("mainDb"))
                                             .ShowSql())
                               .Mappings(map => map
                                                    .FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                               .ExposeConfiguration(BuildSchemaConfiguration)
                               .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        private static void BuildSchemaConfiguration(Configuration obj)
        {
            new SchemaExport(obj).Create(false, true);
        }
    }
}
