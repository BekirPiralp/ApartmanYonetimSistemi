using System.Web.Http;
using System.Web;
using WebUygulamaKatmani.App_Start;

namespace WebUygulamaKatmani
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}