using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWService.OpenAPI.Client
{
    interface IClient
    {
        /// <summary>
        /// 获取地址
        /// </summary>
        /// <returns></returns>
        string GetAddr(string projectName, string action);

        string Get(string url);

        string Post(string url, string data);
    }
}
