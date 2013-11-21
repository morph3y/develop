using System;
using System.Collections.Generic;

namespace Entities.Entities.Base.Resume
{
    public class Resume : BusinessObject
    {
        public virtual String Address { get; set; }
        public virtual String FullName { get; set; }
        public virtual String Phone { get; set; }
        public virtual String Email { get; set; }
        public virtual String ProfessionalObjective { get; set; }
        public virtual IList<Experience> Experiences { get; set; }
        public virtual IList<Skill> Skills { get; set; }
        public virtual IList<Education> Educations { get; set; }

        public Resume()
        {
            Experiences = new List<Experience>();
            Skills = new List<Skill>();
            Educations = new List<Education>();
        }
    }
}
