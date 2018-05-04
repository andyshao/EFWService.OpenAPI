using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EFWService.OpenAPI.Utils;

namespace EFWService.OpenAPI.DynamicController.AutofacExt
{
    public class OpenAPIDependencyResolve : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            return ResolverExtensions.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var obj = ResolverExtensions.Resolve(serviceType);
            return new List<object>() { obj };
        }
    }
}
