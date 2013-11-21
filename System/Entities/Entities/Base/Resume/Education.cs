using System;

namespace Entities.Entities.Base.Resume
{
    public class Education : BusinessObject
    {
        public virtual DateTime DateGraduated { get; set; }
        public virtual String Institution { get; set; }
        public virtual String Diploma { get; set; }
        public virtual Resume Resume { get; set; }
    }
}