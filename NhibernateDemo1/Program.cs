using System;
using System.Linq;
using NHibernate;

namespace NhibernateDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
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
            finally
            {
                NHibernateHelper.CloseSession();
            }
            
            
            Console.WriteLine("Press Enter to exit..");
            Console.ReadLine();
        }
    }
}
