using Entities.Entities;
using FluentNHibernate.Mapping;

namespace DAL.Mappings
{
    internal sealed class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.UserName).Unique().Not.Nullable();
            Map(x => x.Password);
        }
    }
}
