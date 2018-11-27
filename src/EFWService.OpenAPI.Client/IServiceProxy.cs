using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWService.OpenAPI.Client
{
    public interface IServiceProxy
    {
        /// <summary>
        /// get方式获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="projectName"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        T Get<T>(string projectName, string action);
        /// <summary>
        /// post方式获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="projectName"></param>
        /// <param name="action"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        T Post<T>(string projectName, string action, dynamic data);
    }
}
