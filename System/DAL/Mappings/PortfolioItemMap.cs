using Entities.Entities;
using FluentNHibernate.Mapping;

namespace DAL.Mappings
{
    public class PortfolioItemMap : ClassMap<PortfolioItem>
    {
        public PortfolioItemMap()
        {
            Id(x => x.Id);
            Map(x => x.ImageUrl);
            Map(x => x.Description);
            Map(x => x.DateCreated);
        }
    }
}
