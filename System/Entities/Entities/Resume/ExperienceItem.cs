using System;
using Entities.Entities.Base;

namespace Entities.Entities.Resume
{
    public class ExperienceItem : BusinessObject
    {
        public virtual String Description { get; set; }
        public virtual Experience Experience { get; set; }
    }
}