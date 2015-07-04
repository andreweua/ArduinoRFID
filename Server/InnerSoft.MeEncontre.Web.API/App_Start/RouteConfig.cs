using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace InnerSoft.MeEncontre.Web.API
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{local}{colaborador}",
            //    defaults: new { controller = "Acesso", action = "Get", local = RouteParameter.Optional, colaborador = RouteParameter.Optional }
            //);

            routes.MapHttpRoute(
            name: "ApiAcesso",
            routeTemplate: "api/{controller}/{ChaveCliente}/{ChaveLocal}/{ChaveColaborador}",
            defaults: new { ChaveCliente = RouteParameter.Optional, ChaveLocal = RouteParameter.Optional, ChaveColaborador = RouteParameter.Optional }
        );

        }
    }
}