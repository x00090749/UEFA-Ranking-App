using System.Web.Mvc;
using System.Web.Routing;

namespace UefaServiceV9
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("home", "home", new { controller = "Home", action = "Index" });
            routes.MapRoute("admin", "admin", new { controller = "Home", action = "Admin" });
          
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
