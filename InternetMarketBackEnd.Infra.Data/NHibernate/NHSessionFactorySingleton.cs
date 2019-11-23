using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using InternetMarketBackEnd.Infra.Data.Mapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace InternetMarketBackEnd.Infra.Data.NHibernate
{
    public static class NHSessionFactorySingleton
    {
        private static ISessionFactory sessionFactory = null;
        private static object lockObj = new object();

        public static ISessionFactory SessionFactory
        {
            get
            {
                lock (lockObj)
                {
                    if(sessionFactory == null)
                    {
                        sessionFactory = Fluently.Configure()
                            .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Server=SHOHEL-RANA;Database=EMS;User ID=sa;Password=12345;Trusted_Connection=True;Connect Timeout=120;").ShowSql())
                            .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof(OrderMap))))
                            .BuildSessionFactory();
                    }
                    return sessionFactory;
                }
            }
        }
    }
}
