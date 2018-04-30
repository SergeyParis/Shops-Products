using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest()
        {
            HttpContext.Current.Response.Cache.SetAllowResponseInBrowserHistory(false);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetValidUntilExpires(true);
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Initialize();
        }

        private void Initialize()
        {
            ShopsProducts.SDK.eBay.EBayAPI.AppID = "SergeyPa-oil-PRD-be04e9d4e-5f87abbe";

            ShopsProducts.Data.ShopsProductsContext context = new ShopsProducts.Data.ShopsProductsContext();
            context.Database.Delete();
            context.Database.CreateIfNotExists();
        }
    }
}
