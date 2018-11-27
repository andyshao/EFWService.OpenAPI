using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWService.OpenAPI.Client
{
    public class ServiceProxy : IServiceProxy
    {
        private IClient client;
        public ServiceProxy()
        {
            client = new ClientHelper();
        }

        public T Get<T>(string projectName, string action)
        {
            string url = client.GetAddr(projectName, action);
            string result = client.Get(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
        }

        public T Post<T>(string projectName, string action, dynamic data)
        {
            string url = client.GetAddr(projectName, action);
            string result = client.Post(url, data);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
        }
    }
}
