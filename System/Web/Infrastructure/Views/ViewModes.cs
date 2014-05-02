using System.Web;

namespace Web.Infrastructure.Views
{
    internal static class ViewMode
    {
        public static ViewModes Current
        {
            get
            {
                var current = HttpContext.Current.Request.RequestContext.RouteData.Values["viewmode"];
                if (current == null)
                {
                    return ViewModes.None;
                }
                return (ViewModes) current;
            }
        }
    }

    public enum ViewModes
    {
        None, Create, View, Edit, List
    }
}