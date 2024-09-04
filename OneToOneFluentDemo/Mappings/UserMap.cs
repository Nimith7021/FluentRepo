using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using OneToOneFluentDemo.Models;

namespace OneToOneFluentDemo.Mappings
{
    public class UserMap:ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(u => u.Id).GeneratedBy.Identity();
            Map(u => u.Name);
            HasOne(u => u.Address).Cascade.All().PropertyRef(a=>a.User).
                Constrained();
        }
    }
}