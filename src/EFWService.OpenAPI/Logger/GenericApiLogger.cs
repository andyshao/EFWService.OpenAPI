using System;

namespace EFWService.OpenAPI.Logger
{
    /// <summary>
    /// 内置日志记录器
    /// </summary>
    public class GenericLogger : IApiLogger<ApiLogEntity>
    {

        public void Log(ApiLogEntity log)
        {
            if (log.LogType == LogType.Warning)
            {
                Console.WriteLine(log.ToString());
                //TODO warnging log 
                return;
            }
            if (log.LogType == LogType.Debug)
            {
                Console.WriteLine(log.ToString());
                return;
            }
            if (log.Exception != null)
            {
                Console.WriteLine(log.ToString());
                return;
            }
            Console.WriteLine(log.ToString());
        }
    }
}
