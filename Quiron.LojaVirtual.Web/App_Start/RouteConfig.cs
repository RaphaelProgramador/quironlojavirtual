using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Quiron.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");                       

            //1 - Início
            routes.MapRoute(
                name: null,
                url: "",
                defaults: new { controller = "Vitrine", action = "ListarProdutos", categoria = (string)null, pagina = 1 }
            );            

            //2
            routes.MapRoute(
                name: null,
                url: "Pagina{pagina}",
                defaults: new { controller = "Vitrine", action = "ListarProdutos", categoria = (string)null },
                constraints: new { pagina = @"\d+" }
            );            


            //3
            routes.MapRoute(
                name: null,
                url: "{categoria}",
                defaults: new { controller = "Vitrine", action = "ListarProdutos", pagina = 1 }
            );            

            //4
            routes.MapRoute(
                name: null,
                url: "{categoria}/Pagina{pagina}",
                defaults: new { controller = "Vitrine", action = "ListarProdutos" },
                constraints: new { pagina = @"\d+" }
            );             

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}"
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
             
        }
    }
}
