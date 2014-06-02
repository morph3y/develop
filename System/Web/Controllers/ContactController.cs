using System.Web.Mvc;

namespace Web.Controllers
{
    public class ContactController : PresentationController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
