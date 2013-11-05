using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace DAL
{
    internal static class FluentEnvironment
    {
        public static FluentConfiguration GetConfiguration()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008
                    .ConnectionString("Data Source=tcp:s06.winhost.com;Initial Catalog=DB_34514_main;User ID=DB_34514_main_user;Password=z01jh4rQ;Integrated Security=False;")
                )
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));
        }
    }
}
