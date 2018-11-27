using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWService.OpenAPI.Monitor
{
    internal class ServiceMonitor : DefaultApiExecuteAround
    {

        public override void Before(BeforeParam param)
        {
            base.Before(param);
        }

        public override void After(AfterParam param)
        {
            base.After(param);
        }
    }
}
