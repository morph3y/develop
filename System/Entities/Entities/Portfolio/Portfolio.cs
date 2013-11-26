using System;
using Entities.Entities.Base;

namespace Entities.Entities.Portfolio
{
    public class Portfolio : BusinessObject
    {
        public virtual String Description { get; set; }
        public virtual String ImageUrl { get; set; }
    }
}
