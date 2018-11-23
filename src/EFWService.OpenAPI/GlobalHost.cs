using System.Collections.Generic;
using EFWService.OpenAPI.Logger;
using EFWService.OpenAPI.Utils;

namespace EFWService.OpenAPI
{
    /// <summary>
    /// 全局配置
    /// </summary>
    public class GlobalHost
    {
        /// <summary>
        /// 日志记录
        /// </summary>
        public static IApiLogger<ApiLogEntity> ApiLogger
        {
            get
            {
                return WebBaseUtil.ApiLogger;
            }
            set
            {
                WebBaseUtil.ApiLogger = value;
            }
        }
        /// <summary>
        /// 执行管道
        /// </summary>
        public static List<DefaultApiExecuteAround> ApiPipeline
        {
            get
            {
                return WebBaseUtil.ApiExecuteAroundPipeline;
            }
        }

        /// <summary>
        /// 验证管道
        /// </summary>
        public static List<Authentication.Authentication> AuthPipeline
        {
            get
            {
                return WebBaseUtil.AuthenticationPipeline;
            }
        }

    }
}
