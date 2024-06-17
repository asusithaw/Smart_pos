using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManipulations.Entities
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? Address { get; set; }
    }

    public sealed class  CustomerMap : ClassMap<Customer>
    {
        public CustomerMap() 
        {
            Table("CUSTOMERS");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Address);
        }
        
    }
}
