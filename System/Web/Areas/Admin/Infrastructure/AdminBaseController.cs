using System.Security;
using System.Web.Mvc;

namespace Web.Areas.Admin.Infrastructure
{
    public class AdminBaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!User.Identity.IsAuthenticated)
            {
                throw new SecurityException("Only registered users can access this.");
            }
        }
    }
}
