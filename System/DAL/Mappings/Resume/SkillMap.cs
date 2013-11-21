using System;
using Entities.Entities.Base.Resume;
using FluentNHibernate.Mapping;

namespace DAL.Mappings.Resume
{
    public class SkillMap : SubclassMap<Skill>
    {
        public SkillMap()
        {
            KeyColumn("Id");
            Map(x => x.Description).Not.Nullable();
            Map(x => x.SkillType).CustomType<Int32>().Not.Nullable();

            References(x => x.Resume).Column("Resume_id").Fetch.Select();
        }
    }
}
