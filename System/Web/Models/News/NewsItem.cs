using System;

namespace Web.Models.News
{
    public class NewsItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}