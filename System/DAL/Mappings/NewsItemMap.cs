using Entities.Entities;
using FluentNHibernate.Mapping;

namespace DAL.Mappings
{
    public class NewsItemMap : SubclassMap<NewsItem>
    {
        public NewsItemMap()
        {
            KeyColumn("Id");
            Map(x => x.Text);
            Map(x => x.Title);
        }
    }
}
