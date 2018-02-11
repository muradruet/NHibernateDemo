using FluentNHibernate.Mapping;

namespace NhibernateDemo.Mapping
{
    public class CustomerMapping : ClassMap<Customer>
    {
        public CustomerMapping()
        {
            Table("Customer");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.Email);
        }
    }
}
