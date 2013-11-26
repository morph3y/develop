using Entities.Entities.Resume;
using FluentNHibernate.Mapping;

namespace DAL.Mappings.Resume
{
    public class EducationMap : SubclassMap<Education>
    {
        public EducationMap()
        {
            KeyColumn("Id");
            Map(x => x.DateGraduated).Not.Nullable();
            Map(x => x.Diploma).Not.Nullable();
            Map(x => x.Institution).Not.Nullable();

            References(x => x.Resume).Column("Resume_id").Fetch.Select();
        }
    }
}
