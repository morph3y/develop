using System;

namespace Entities.Entities
{
    public class NewsItem : BusinessObject
    {
        public virtual string Title { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime DatePosted { get; set; }
    }
}
