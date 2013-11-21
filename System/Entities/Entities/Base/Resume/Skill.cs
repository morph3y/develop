using System;

namespace Entities.Entities.Base.Resume
{
    public class Skill : BusinessObject
    {
        public virtual String Description { get; set; }
        public virtual SkillType SkillType { get; set; }
        public virtual Resume Resume { get; set; }
    }
}