using System;
using System.Linq;
using System.Web.Mvc;
using Entities.Entities;
using Framework.Common.Contracts;
using Framework.Grid;
using Web.Areas.Admin.Infrastructure;
using Web.Infrastructure;

namespace Web.Areas.Admin.Controllers
{
    public class NewsController : AdminBaseController, IGridEmbededController
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

        public PartialViewResult GetPage(Int32? page, Int32? pageSize)
        {
            if (!page.HasValue || !pageSize.HasValue)
            {
                return null;
            }
            var objects =
                ObjectService.Get<NewsItem>(page.Value, pageSize.Value, x => x.DatePosted).OrderByDescending(
                    x => x.DatePosted);
            var gdd = new GridDataDefinition(objects.OfType<BusinessObject>().ToList())
                          {
                              CurrentPage = page.Value,
                              ItemsPerPage = pageSize.Value,
                              Area = Url.RequestContext.RouteData.DataTokens["area"].ToString(),
                              Controller = Url.RequestContext.RouteData.Values["controller"].ToString(),
                              Action = Url.RequestContext.RouteData.Values["action"].ToString()
                          };
            return PartialView("Grid", gdd);
        }
    }
}
