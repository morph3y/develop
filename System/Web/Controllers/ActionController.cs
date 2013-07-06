using System.Web.Mvc;

namespace Web.Controllers
{
    public class ActionController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // do stuff
            base.OnActionExecuting(filterContext);
        }
    }
}