using System;
using System.Web.Mvc;

namespace Web.Infrastructure.Views
{
    public class ViewModeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            String actionName = filterContext.ActionDescriptor.ActionName;
            if (actionName.Equals("view", StringComparison.OrdinalIgnoreCase))
            {
                filterContext.RouteData.Values.Add("viewmode", ViewModes.View);
            }
            else if (actionName.Equals("edit", StringComparison.OrdinalIgnoreCase))
            {
                filterContext.RouteData.Values.Add("viewmode", ViewModes.Edit);
            }
            else if (actionName.Equals("create", StringComparison.OrdinalIgnoreCase))
            {
                filterContext.RouteData.Values.Add("viewmode", ViewModes.Create);
            }
            else if (actionName.Equals("index", StringComparison.OrdinalIgnoreCase))
            {
                filterContext.RouteData.Values.Add("viewmode", ViewModes.List);
            }
            else
            {
                filterContext.RouteData.Values.Add("viewmode", ViewModes.None);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}