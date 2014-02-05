using System.Web.Mvc;
using Web.Areas.Admin.Controllers.Framework;

namespace Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
