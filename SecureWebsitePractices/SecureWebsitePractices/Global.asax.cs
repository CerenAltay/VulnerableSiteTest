using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SecureWebsitePractices
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
    //public class Global : HttpApplication
    //{
    //    void Application_Start(object sender, EventArgs e)
    //    {
    //        // Code that runs on application startup
    //        BundleConfig.RegisterBundles(BundleTable.Bundles);
    //        RouteConfig.RegisterRoutes(RouteTable.Routes);
    //    }
    //}
}
