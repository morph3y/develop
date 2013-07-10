using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;
using Web.Bootstrap;

namespace Web
{
    public class MvcApplication : HttpApplication 
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new[] { "Web.Controllers" }
            );

        }

        protected void Application_Start(object sender, EventArgs e) 
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            Bootstraper.Initialize();

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }
    }
}