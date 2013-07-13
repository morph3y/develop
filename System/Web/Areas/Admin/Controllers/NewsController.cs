using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Entities.Entities;
using Framework.Common.Contracts;

namespace Web.Areas.Admin.Controllers
{
    public class NewsController : AdminBaseController
    {
        public IObjectService ObjectService { get; set; }
        public NewsController(IObjectService objectService)
        {
            ObjectService = objectService;
        }

        public ActionResult Index()
        {
            return View("News");
        }

        public ActionResult GetData(Int32? page, Int32? pageSize)
        {
            IList<NewsItem> model;
            if (!page.HasValue || !pageSize.HasValue)
            {
                model = ObjectService.Get<NewsItem>();
            }
            else
            {
                model = ObjectService.Get<NewsItem>(page.Value, pageSize.Value, x=>x.DatePosted);
            }
            return PartialView("Grid", model);
        }
    }
}
