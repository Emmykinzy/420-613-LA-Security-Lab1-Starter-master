using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Original",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);


            routes.MapRoute(
              name: "EmptyUrl",
              url: "",
              defaults: new { controller = "Home", action = "Index" }
          );

            routes.MapRoute(
              name: "Inventory",
              url: "Inventory/Index",
              new { controller = "Inventory", action = "Index" }
          );

            routes.MapRoute(
               name: "Home",
               url: "Home/{action}",
               new { controller = "Home", action = "Index" },
               constraints: new { action = "Contanct|About|Index" }
           );

            routes.MapRoute(
              name: "Account",
              url: "Account/{action}",
              new { controller = "Account", action = "Login" },
              constraints: new { action = "Login|Logoff" }
          );

            routes.MapRoute(
            name: "CatchAll",
            url: "{*any}",
            defaults: new { controller = "Error", action = "Notfound" }
            );


        }
    }
}
