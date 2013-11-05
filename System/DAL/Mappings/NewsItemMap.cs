﻿using Entities.Entities;
using FluentNHibernate.Mapping;

namespace DAL.Mappings
{
    public class NewsItemMap : ClassMap<NewsItem>
    {
        public NewsItemMap()
        {
            Id(x => x.Id);
            Map(x => x.Text);
            Map(x => x.Title);
            Map(x => x.DateCreated);
        }
    }
}