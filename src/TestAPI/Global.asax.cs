using EFWService.OpenAPI;
using EFWService.OpenAPI.Logger;
using System.Web.Routing;

namespace TestAPI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalHost.ApiLogger = new APILogger();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            OpenAPIHelper.Init();
        }
    }
}
