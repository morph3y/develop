using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
