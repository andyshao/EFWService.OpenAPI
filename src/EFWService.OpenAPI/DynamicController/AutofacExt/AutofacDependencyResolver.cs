using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;

namespace EFWService.OpenAPI.DynamicController.AutofacExt
{
    public class AutofacDependencyResolver : IDependencyResolver
    {
        public IContainer container;
        public AutofacDependencyResolver(IContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            if (container.IsRegistered(serviceType))
                return container.Resolve(serviceType);
            return null;
        }

        internal IEnumerable<T> GetTypeServices<T>(T serviceType)
        {
            return container.Resolve<IEnumerable<T>>();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return GetTypeServices(serviceType);
        }
    }
}
