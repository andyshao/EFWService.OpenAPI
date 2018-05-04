using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace EFWService.OpenAPI.Utils
{
    internal class AutofacEx
    {
        private static ContainerBuilder builder = new ContainerBuilder();
        private static IContainer autofacContainer;
        private static bool IsInit = false;
        private static readonly object obj = new object();

        /// <summary>
        /// 容器
        /// </summary>
        public static IContainer Container
        {
            get
            {
                return autofacContainer;
            }
        }
        /// <summary>
        /// 构建器
        /// </summary>
        public static ContainerBuilder Builder
        {
            get { return builder; }
        }
        /// <summary>
        /// 构建
        /// </summary>
        public static void Build()
        {
            lock (obj)
            {
                if (IsInit)
                {
                    return;
                }
                autofacContainer = builder.Build();
                IsInit = true;
            }
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }


        public static IEnumerable<T> Resolves<T>()
        {
            return Container.Resolve<IEnumerable<T>>();
        }

        public static object Resolve(Type t)
        {
            return Container.Resolve(t);
        }
    }
}
