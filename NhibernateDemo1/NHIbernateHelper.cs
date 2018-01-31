using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace NhibernateDemo1
{
    class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory _sessionFactory;
        static NHibernateHelper()
        {
            _sessionFactory = new Configuration().Configure().BuildSessionFactory();
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
    }
}
