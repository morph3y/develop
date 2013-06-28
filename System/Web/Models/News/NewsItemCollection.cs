using System.Collections.Generic;
using System.Linq;

namespace Web.Models.News
{
    public class NewsItemCollection
    {
        // TODO: Move to Business
        public NewsItemCollection()
        {
            _items = new List<NewsItem>();
        }

        private List<NewsItem> _items;
        public List<NewsItem> Items
        {
            get { return _items; }
        }

        public void Add(NewsItem item)
        {
            if (!_items.Any(x => x.Id == item.Id))
            {
                _items.Add(item);
            }
        }
    }
}