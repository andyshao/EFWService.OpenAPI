using EFWService.OpenAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EFWService.OpenAPI.Register
{
    /// <summary>
    /// API 控制中心注册
    /// </summary>
    public class RegisterHelper
    {
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="basePath"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        public static async Task RegisterAsync(string basePath, string env)
        {
            var meta = WebBaseUtil.ApiMethodMetaCache;
            var obj = new
            {
                path = basePath,
                env = env,
                meta = meta
            };
            string json = JsonConvertExd.SerializeObject(obj);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(json);
            await client.PostAsync("", content).ConfigureAwait(false);
        }
    }
}
