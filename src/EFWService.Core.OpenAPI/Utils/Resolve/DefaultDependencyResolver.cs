using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EFWService.Core.OpenAPI.Utils.Resolve
{
    public class DefaultDependencyResolver : IDependencyResolver
    {
        private readonly Dictionary<Type, Dictionary<string, object>> keysResolvers = new Dictionary<Type, Dictionary<string, object>>();
        private readonly Dictionary<Type, object> resolvers = new Dictionary<Type, object>();

        private readonly HashSet<IDisposable> _trackedDisposables = new HashSet<IDisposable>();
        private int _disposed;
        public void Dispose()
        {
            if (Interlocked.Exchange(ref _disposed, 1) == 0)
            {
                resolvers.Clear();
                _trackedDisposables.Clear();
            }
        }

        public object GetService(Type serviceType)
        {
            object obj;
            if (resolvers.TryGetValue(serviceType, out obj))
            {
                return Track(() => { return obj; });
            }
            return null;
        }

        public object GetServiceByKey(Type t, string key)
        {
            object obj;
            Dictionary<string, object> keyDic;
            if (keysResolvers.TryGetValue(t, out keyDic))
            {
                if (keyDic.TryGetValue(key, out obj))
                {
                    return obj;
                }
            }
            return null;
        }

        public bool IsRegister(Type serviceType)
        {
            return resolvers.Keys.Contains(serviceType);
        }

        public bool IsRegisterByKey(Type serviceType, string key)
        {
            if (!keysResolvers.ContainsKey(serviceType))
            {
                return false;
            }
            return keysResolvers[serviceType].ContainsKey(key);
        }
        public void Register(Type serviceType, Func<object> activator)
        {
            var obj = activator();
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
            Object activat;
            if (!resolvers.TryGetValue(serviceType, out activat))
            {
                if (activat != null)
                {
                    activat = new object();
                    resolvers.Add(serviceType, activat);
                }
                else
                {
                    activat = obj;
                }
            }
        }
        public void RegisterByKey(Type serviceType, Func<object> activator, string key)
        {
            var obj = activator();
            Dictionary<string, object> dicObj;
            if (!keysResolvers.TryGetValue(serviceType, out dicObj))
            {
                dicObj = new Dictionary<string, object>();
                dicObj.Add(key, obj);
                keysResolvers.Add(serviceType, dicObj);
            }
            else
            {
                object oldObj;
                if (!dicObj.TryGetValue(key, out oldObj))
                {
                    dicObj.Add(key, obj);
                }
                else
                {
                    oldObj = obj;
                }
            }
        }

        private object Track(Func<object> creator)
        {
            object obj = creator();

            if (_disposed == 0)
            {
                var disposable = obj as IDisposable;
                if (disposable != null)
                {
                    lock (_trackedDisposables)
                    {
                        if (_disposed == 0)
                        {
                            _trackedDisposables.Add(disposable);
                        }
                    }
                }
            }
            return obj;
        }
    }
}
