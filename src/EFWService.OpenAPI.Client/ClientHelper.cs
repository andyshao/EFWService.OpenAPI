using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWService.OpenAPI.Client
{
    public class ClientHelper : IClient
    {
        public string GetAddr(string projectName, string action)
        {
            string url = string.Empty;
            //根据项目获取ip,然后轮训获取一个地址
            string host = "";
            string path = action.Replace('.', '/');
            return $"http://{host}/{path}";
        }
        public string Get(string url)
        {
            return string.Empty;
        }
        public string Post(string url, string data)
        {
            return string.Empty;
        }
    }
}
