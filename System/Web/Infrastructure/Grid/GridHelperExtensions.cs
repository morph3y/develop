using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Web.Infrastructure.Grid
{
    public static class GridHelperExtensions
    {
        public static IHtmlString Grid(this HtmlHelper helper, Type entityType, List<String> columns, IEnumerable gridData = null)
        {
            var grid = new Grid(entityType, columns, gridData);
            return new HtmlString(grid.Render());
        }
    }
}