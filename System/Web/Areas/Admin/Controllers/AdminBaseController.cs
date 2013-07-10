using System.Security;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!User.Identity.IsAuthenticated)
            {
                throw new SecurityException("Only register user can access this.");
            }
        }
    }
}
