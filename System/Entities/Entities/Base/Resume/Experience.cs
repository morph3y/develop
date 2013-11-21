using System;
using System.Collections.Generic;

namespace Entities.Entities.Base.Resume
{
    public class Experience : BusinessObject
    {
        public virtual DateTime DateStarted { get; set; }
        public virtual DateTime DateEnded { get; set; }
        public virtual String CompanyName { get; set; }
        public virtual String Position { get; set; }
        public virtual IList<ExperienceItem> Items { get; set; }
        public virtual Resume Resume { get; set; }

        public Experience()
        {
            Items = new List<ExperienceItem>();
        }
    }
}