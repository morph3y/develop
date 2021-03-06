﻿using Entities.Entities.Portfolio;
using FluentNHibernate.Mapping;

namespace DAL.Mappings
{
    public class PortfolioItemMap : SubclassMap<Portfolio>
    {
        public PortfolioItemMap()
        {
            KeyColumn("Id");
            Map(x => x.ImageUrl);
            Map(x => x.Description);
            Map(x => x.Url);
        }
    }
}
