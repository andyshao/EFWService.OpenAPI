using System;
using TongCheng.AppInfoCenter;

namespace EFWService.OpenAPI.Logger
{
    /// <summary>
    /// 内置日志记录器
    /// </summary>
    public class GenericLogger : IApiLogger<ApiLogEntity>
    {

        public void Log(ApiLogEntity log)
        {
            log.LogFinish();
            Action<string, string, string, string, ExtraInfo> logAction = TongCheng.AppInfoCenter.CommonService.LogService.Info;
            if (log.LogType == LogType.Warning)
            {
                logAction = TongCheng.AppInfoCenter.CommonService.LogService.Warning;
            }
            if (log.LogType == LogType.Debug)
            {
                logAction = TongCheng.AppInfoCenter.CommonService.LogService.Debug;
            }
            if (log.Exception != null)
            {
                log.Exception.Handle(
                   log.ModuleName,
                   log.CategoryName,
                   log.SubcategoryName,
                   log.Message, new TongCheng.AppInfoCenter.ExtraInfo()
                   {
                       //异常跟踪ID不为空 TextBoxFilterItem1 值替换为 ExceptionId
                       TextBoxFilterItem1 = string.IsNullOrEmpty(log.ExceptionId) ? log.TextBoxFilterItem1 : log.ExceptionId,
                       TextBoxFilterItem2 = log.TextBoxFilterItem2,
                       DisplayItems = log.DisplayItems
                   });
            }
            else
            {
                logAction(log.ModuleName,
                       log.CategoryName,
                       log.SubcategoryName,
                       log.Message, new TongCheng.AppInfoCenter.ExtraInfo()
                       {
                           TextBoxFilterItem1 = log.TextBoxFilterItem1,
                           TextBoxFilterItem2 = log.TextBoxFilterItem2,
                           DisplayItems = log.DisplayItems
                       });
            }
        }
    }
}
