using System;
using System.Web.Mvc;
using Entities.Entities;
using Framework.Common.Contracts;

namespace Web.Controllers
{
    public class NewsController : Controller
    {
        public NewsController(IObjectService objectService)
        {
            ObjectService = objectService;
        }

        public IObjectService ObjectService { get; set; }

        public ActionResult Index()
        {
            var model = ObjectService.Get<NewsItem>(Guid.Parse("655e363a-48e2-41dc-bdca-a1f400c2b574"));
            return View("News", model);
        }
    }
}
