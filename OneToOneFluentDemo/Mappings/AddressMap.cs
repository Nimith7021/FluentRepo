using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using OneToOneFluentDemo.Models;

namespace OneToOneFluentDemo.Mappings
{
    public class AddressMap:ClassMap<Address>
    {
        public AddressMap()
        {
            Table("Addresses");
            Id(a => a.Id).GeneratedBy.Identity();
            Map(a => a.Street);
            Map(a => a.City);
            References(a => a.User).Column("user_id").Unique().Cascade.None();
        }
    }
}