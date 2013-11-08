using System;
using Entities.Entities.Base;

namespace Entities.Entities
{
    public class NewsItem : BusinessObject
    {
        public virtual String Title { get; set; }
        public virtual String Text { get; set; }
        public virtual DateTime DateCreated { get; set; }
    }
}
