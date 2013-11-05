using System;

namespace Entities.Entities
{
    public class NewsItem
    {
        public virtual Int32 Id { get; protected set; }
        public virtual String Title { get; set; }
        public virtual String Text { get; set; }
        public virtual DateTime DateCreated { get; set; }
    }
}
