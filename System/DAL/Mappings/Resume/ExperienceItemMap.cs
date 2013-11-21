using Entities.Entities.Base.Resume;
using FluentNHibernate.Mapping;

namespace DAL.Mappings.Resume
{
    public class ExperienceItemMap : SubclassMap<ExperienceItem>
    {
        public ExperienceItemMap()
        {
            KeyColumn("Id");
            Map(x => x.Description).Not.Nullable();

            References(x => x.Experience).Column("Experience_id").Fetch.Select();
        }
    }
}
