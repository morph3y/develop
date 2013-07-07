using System;
using System.Web.Mvc;
using Business.Contracts;
using Entities.Entities;
using Ninject;

namespace Web.Controllers
{
    public class NewsController : Controller
    {
        [Inject]
        public IObjectService ObjectService { get; set; }

        public ActionResult Index()
        {
            var model = ObjectService.Get<NewsItem>(Guid.Parse("655e363a-48e2-41dc-bdca-a1f400c2b574"));
            return View("News", model);
        }
    }
}
