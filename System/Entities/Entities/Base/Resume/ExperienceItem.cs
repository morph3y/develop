using System;

namespace Entities.Entities.Base.Resume
{
    public class ExperienceItem : BusinessObject
    {
        public virtual String Description { get; set; }
        public virtual Experience Experience { get; set; }
    }
}