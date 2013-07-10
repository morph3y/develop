using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class NewsController : AdminBaseController
    {
        public ActionResult Index()
        {
            return View("News");
        }
    }
}
