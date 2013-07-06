using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : ActionController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "News");
        }
    }
}
