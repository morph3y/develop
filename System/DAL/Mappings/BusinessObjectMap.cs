using System;
using Entities.Entities.Base;
using FluentNHibernate.Mapping;

namespace DAL.Mappings
{
    public class BusinessObjectMap : ClassMap<BusinessObject>
    {
        public BusinessObjectMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.HiLo("1");
            Map(x => x.DateCreated).Access.Property().Default("getdate()").Not.Insert().Not.Update().Generated.Always().Not.Nullable();
        }
    }
}
