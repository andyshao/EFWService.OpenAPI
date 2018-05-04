using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;

namespace EFWService.Core.OpenAPI.DynamicController.AutofacExt
{
    public class APIControllerActivator : IControllerActivator
    {
        public APIControllerActivator() { }
        static readonly string ControllerKey = "DynamicWeb_{0}";

        public static string CreateControllerKey(string controllerName)
        {
            return string.Format(ControllerKey, controllerName).ToLower();
        }
        public object Create(ControllerContext context)
        {

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.ActionDescriptor == null)
            {
                throw new ArgumentException("controller is null!");
            }
            string key = string.Format(ControllerKey + "Controller", context.ActionDescriptor.ControllerName).ToLower();
            //if (AutofacEx.Container.IsRegisteredWithKey<Controller>(key))
            //{
            //    return AutofacEx.Container.ResolveKeyed<Controller>(key);
            //}
            return null;

        }

        public void Release(ControllerContext context, object controller)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }

            var disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
