using System.Reflection;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NhibernateDemo.Mapping;
using NHibernate;
using NHibernate.Cfg;

namespace NhibernateDemo
{
    class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory _sessionFactory;
        static NHibernateHelper()
        {
            //... using NHibernate configuration ...
            // _sessionFactory = new Configuration().Configure().BuildSessionFactory();
            
            //... using fluent....
            _sessionFactory = FluentConfigure();
        }
        public static ISession GetCurrentSession()
        {
            //// un-comment for web project
            //var context = HttpContext.Current;
            //var currentSession = context.Items[CurrentSessionKey] as ISession;
            //if (currentSession == null)
            //{
            //    currentSession = _sessionFactory.OpenSession();
            //    context.Items[CurrentSessionKey] = currentSession;
            //}
            //return currentSession;
            return _sessionFactory.OpenSession();
        }
        public static void CloseSession()
        {
            //// un-comment for web project
            //var context = HttpContext.Current;
            //var currentSession = context.Items[CurrentSessionKey] as ISession;
            //if (currentSession == null)
            //{
            //    // No current session
            //    return;
            //}
            //currentSession.Close();
            //context.Items.Remove(CurrentSessionKey);

            _sessionFactory.Close();
        }
        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }

        public static ISessionFactory FluentConfigure()
        {
            return Fluently.Configure()
                //which database
                .Database(
                    MsSqlConfiguration.MsSql2012
                        .ConnectionString(
                            cs => cs.FromConnectionStringWithKey("DBConnection")) //connection string from app.config
                                                                                  //.ShowSql()
                        )
                //2nd level cache
                .Cache(
                    c => c.UseQueryCache()
                        .UseSecondLevelCache()
                        .ProviderClass<NHibernate.Cache.HashtableCacheProvider>())
                //find/set the mappings
                //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}
