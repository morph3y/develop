using System.Linq;
using System.Web.Mvc;
using Contracts.Business;
using Entities.Entities;
using Framework.Common;
using Framework.Common.Query;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private IObjectService ObjectService
        {
            get { return ApplicationEnvironment.Resolve<IObjectService>(); }
        }

        public ActionResult Index()
        {
            var items = ObjectService.GetCollection<NewsItem>(3, x=>x.DateCreated, OrderByDirection.Descending).ToList();
            return View(items);
        }
    }
}
