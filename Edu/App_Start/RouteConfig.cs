using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Edu
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "{controller}/{action}/Page{page}",
                new { controller = "Course", action = "Courses" },
                new { page = @"\d+" }
            );


            routes.MapRoute(null, "{controller}/{action}/Page{page}/{id}",
                new { controller = "Course", action = "Courses", item = UrlParameter.Optional },
                new { page = @"\d+", item = @"\d+" }
            );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
