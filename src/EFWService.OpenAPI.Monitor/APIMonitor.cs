using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWService.OpenAPI.Monitor
{
    public class APIMonitor
    {
        /// <summary>
        /// 添加监控
        /// </summary>
        public static void AddMonintor()
        {
            GlobalHost.ApiPipeline.Add(new ServiceMonitor());
        }
    }
}
