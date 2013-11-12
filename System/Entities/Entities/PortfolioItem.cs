using System;
using Entities.Entities.Base;

namespace Entities.Entities
{
    public class PortfolioItem : BusinessObject
    {
        public virtual String Description { get; set; }
        public virtual String ImageUrl { get; set; }
    }
}
