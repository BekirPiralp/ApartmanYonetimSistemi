using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebUygulamasiApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API yapılandırması ve hizmetleri

            // Web API yolları
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}"
                //defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
