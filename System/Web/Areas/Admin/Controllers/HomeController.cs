using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "News");
        }
    }
}
