using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWService.Core.OpenAPI.Utils.Resolve
{
    public interface IDependencyResolver : IDisposable
    {
        object GetService(Type serviceType);
        object GetServiceByKey(Type serviceType,string key);
        void Register(Type serviceType, Func<object> activator);
        void RegisterByKey(Type serviceType, Func<object> activators, string key);
        bool IsRegister(Type serviceType);
        bool IsRegisterByKey(Type serviceType, string key);
    }
}
