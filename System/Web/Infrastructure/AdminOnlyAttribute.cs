using System;
using System.Web.Mvc;

namespace Web.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    internal sealed class AdminOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                throw new AccessViolationException("You are not logged in!");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}