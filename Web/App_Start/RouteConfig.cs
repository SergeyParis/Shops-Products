using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Shops", action = "Index"}
            );

            routes.MapRoute(
                name: "Ebay",
                url: "{controller}/{action}/{query}/{pageIndex}",
                namespaces: new[] { "~/Views/Shops/eBay/" },
                defaults: new { controller = "Shops", action = "EBay",
                                query = "", pageIndex = 1 }
                );

            routes.MapRoute(
                name: "EbayItem",
                url: "ShopsController/EbayItem/{id}"
                );
        }
    }
}
