using System;
using System.Linq;
using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace NhibernateDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var cfg = new Configuration();
            //cfg.DataBaseIntegration(x =>
            //{
            //    x.ConnectionString = "Data Source=.;Initial Catalog=NHibernateDemo;Integrated Security=True;";
            //    x.Driver<SqlClientDriver>();
            //    x.Dialect<MsSql2012Dialect>();
            //});
            //cfg.AddAssembly(Assembly.GetExecutingAssembly());
            //var sessionFactory = cfg.BuildSessionFactory();

            var sessionFactory = new Configuration().Configure().BuildSessionFactory();
            
            using (var session = sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var customers = from customer in session.Query<Customer>()
                               select customer;

                    foreach (var f in customers)
                    {
                        Console.WriteLine("{0} {1}", f.Id, f.Name);
                    }
                    tx.Commit();
                }
            }
            Console.WriteLine("Press any key to exit..");
            Console.ReadLine();
        }
    }
}
