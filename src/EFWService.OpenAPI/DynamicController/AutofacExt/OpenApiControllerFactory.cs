using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using EFWService.OpenAPI.Utils;

namespace EFWService.OpenAPI.DynamicController.AutofacExt
{
    public class OpenApiControllerFactory : DefaultControllerFactory
    {
        static readonly string ControllerKey = "DynamicWeb_{0}";

        internal static string CreateControllerKey(string controllerName)
        {
            return string.Format(ControllerKey, controllerName).ToLower();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                string key = string.Format(ControllerKey + "Controller", requestContext.RouteData.Values["controller"]).ToLower();
                if (ResolverExtensions.IsRegisterByKey<IController>(key))
                {
                    return ResolverExtensions.ResolveByKey<IController>(key);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
