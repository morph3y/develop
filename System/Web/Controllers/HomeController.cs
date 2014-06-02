using System.Linq;
using System.Web.Mvc;
using Entities.Entities;
using Framework.Common.Query;

namespace Web.Controllers
{
    public class HomeController : PresentationController
    {
        public ActionResult Index()
        {
            var items = ObjectService.GetCollection<NewsItem>(3, x=>x.DateCreated, OrderByDirection.Descending).ToList();
            return View(items);
        }
    }
}
