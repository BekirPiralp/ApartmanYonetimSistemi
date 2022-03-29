using System.Linq;
using System.Web.Http;

namespace WebUygulamaKatmani.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}"
                //defaults: new { id = RouteParameter.Optional }
            );

            var xml = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(p => p.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(xml);
        }
    }
}