using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernateDemo1
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
