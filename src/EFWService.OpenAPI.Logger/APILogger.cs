using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TongCheng.LiveChat.Utility.Logger;

namespace EFWService.OpenAPI.Logger
{
    public class APILogger : IApiLogger<ApiLogEntity>
    {
        private ILogger logger;
        public APILogger()
        {
            logger = new LoggerHelper();
        }

        public void Log(ApiLogEntity log)
        {
            if (log.LogType == LogType.Warning)
            {
                logger.Warning(log.CategoryName, log.ModuleName, log.SubcategoryName, log.Message,
                    log.DisplayItems, log.TextBoxFilterItem1, log.TextBoxFilterItem2);
                return;
            }
            if (log.LogType == LogType.Debug)
            {
                logger.Debug(log.CategoryName, log.ModuleName, log.SubcategoryName, log.Message,
                   log.DisplayItems, log.TextBoxFilterItem1, log.TextBoxFilterItem2);
                return;
            }
            if (log.LogType == LogType.Error)
            {
                logger.Error(log.Exception, log.CategoryName, log.ModuleName, log.SubcategoryName, log.Message,
                   log.DisplayItems, log.TextBoxFilterItem1, log.TextBoxFilterItem2);
                return;
            }
            logger.Info(log.CategoryName, log.ModuleName, log.SubcategoryName, log.Message,
                    log.DisplayItems, log.TextBoxFilterItem1, log.TextBoxFilterItem2);
        }
    }
}
