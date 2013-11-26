using FluentNHibernate.Mapping;

namespace DAL.Mappings.Resume
{
    public class ResumeMap : SubclassMap<Entities.Entities.Resume.Resume>
    {
        public ResumeMap()
        {
            KeyColumn("Id");
            Map(x => x.Email).Not.Nullable();
            Map(x => x.Address).Nullable();
            Map(x => x.FullName).Not.Nullable();
            Map(x => x.Phone).Not.Nullable();
            Map(x => x.ProfessionalObjective).Not.Nullable();

            HasMany(x => x.Educations).KeyColumns.Add("Resume_id").Cascade.All();
            HasMany(x => x.Experiences).KeyColumns.Add("Resume_id").Cascade.All();
            HasMany(x => x.Skills).KeyColumns.Add("Resume_id").Cascade.All();
        }
    }
}
