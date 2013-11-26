using FluentNHibernate.Mapping;

namespace DAL.Mappings.User
{
    public class UserMap : ClassMap<Entities.Entities.User.User>
    {
        public UserMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Password).Not.Nullable();
            Map(x => x.UserName).Not.Nullable();
        }
    }
}
