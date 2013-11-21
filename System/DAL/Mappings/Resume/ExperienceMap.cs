using Entities.Entities.Base.Resume;
using FluentNHibernate.Mapping;

namespace DAL.Mappings.Resume
{
    public class ExperienceMap : SubclassMap<Experience>
    {
        public ExperienceMap()
        {
            KeyColumn("Id");
            Map(x => x.CompanyName).Not.Nullable();
            Map(x => x.DateEnded).Nullable();
            Map(x => x.DateStarted).Not.Nullable();
            Map(x => x.Position).Not.Nullable();

            HasMany(x => x.Items).KeyColumns.Add("Experience_id").Cascade.All();

            References(x => x.Resume).Column("Resume_id").Fetch.Select();
        }
    }
}
