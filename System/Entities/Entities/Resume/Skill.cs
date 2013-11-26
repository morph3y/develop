using System;
using Entities.Entities.Base;

namespace Entities.Entities.Resume
{
    public class Skill : BusinessObject
    {
        public virtual String Description { get; set; }
        public virtual SkillType SkillType { get; set; }
        public virtual Entities.Resume.Resume Resume { get; set; }
    }
}