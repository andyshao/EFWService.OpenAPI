using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWService.OpenAPI.Utils.Resolve;

namespace EFWService.OpenAPI.Utils
{
    internal class ResolverExtensions
    {
        private static DefaultDependencyResolver container;
        static ResolverExtensions()
        {
            container = new Lazy<DefaultDependencyResolver>(() => new DefaultDependencyResolver()).Value;
        }

        //public static DefaultDependencyResolver Container
        //{
        //    get
        //    {
        //        return container;
        //    }
        //}

        public static bool IsRegisterByKey<T>(string key)
        {
            return container.IsRegisterByKey(typeof(T), key);
        }
        public static T ResolveByKey<T>(string key)
        {
            return (T)container.GetServiceByKey(typeof(T), key);
        }
        public static bool IsRegister<T>()
        {
            return container.IsRegister(typeof(T));
        }
        public static object Resolve<T>(T t)
            where T : Type
        {
            return container.GetService(t);
        }
    }
}
