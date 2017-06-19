using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{area}/{controller}/{action}/{id}",
                //se debe modificar el router y agregarle el area, el area principal sera igual a "", porque no esta en la carpeta areas
                defaults: new { area="", controller = "Home", action = "Index", id = UrlParameter.Optional },
                //direccion donde se encuentran los controladores principales
                namespaces: new string[] { "WebApp.Controllers"}
            );
        }
    }
}
