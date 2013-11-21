using System;

namespace Entities.Entities.Base.Portfolio
{
    public class Portfolio : BusinessObject
    {
        public virtual String Description { get; set; }
        public virtual String ImageUrl { get; set; }
    }
}
