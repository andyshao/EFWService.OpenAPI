/* ======================================================================== 
 * Copyright (c) 同程网络科技股份有限公司. All rights reserved.
 * 文 件 名：LoggerHelper.cs      
 * 创 建 人：cgy6094
 * 创建日期： 2018/3/9 14:06:52
 * 用    途：LoggerHelper Class File
 * ======================================================================== */
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using static System.String;

namespace TongCheng.LiveChat.Utility.Logger
{
    /// <summary>
    /// 处理日志信息
    /// </summary>
    internal class LoggerHelper : ILogger
    {
        const string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} {Message}{NewLine}{Exception}";
        /// <summary>
        /// 初始化
        /// </summary>
        static LoggerHelper()
        {
            string logPath = System.Configuration.ConfigurationManager.AppSettings["logPath"];
            if (IsNullOrEmpty(logPath))
            {
                logPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/");
            }
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Hour, outputTemplate: outputTemplate, encoding: Encoding.UTF8)
                .CreateLogger();
        }

        /// <summary>
        /// info日志
        /// </summary>
        /// <param name="category"></param>
        /// <param name="subcategory"></param>
        /// <param name="message"></param>
        /// <param name="extend"></param>
        public void Info(string module, string category, string subcategory, string message,
            Dictionary<string, string> extend = null, string filter1 = "", string filter2 = "")
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Info ");
                ProcessMessage(sb, module, category, subcategory, message, filter1, filter2);
                ProcessExtend(sb, extend);
                Log.Information(sb.ToString());
            }
            catch { }
        }

        /// <summary>
        /// info日志
        /// </summary>
        /// <param name="category"></param>
        /// <param name="subcategory"></param>
        /// <param name="message"></param>
        /// <param name="extend"></param>
        public void Debug(string module, string category, string subcategory, string message,
            Dictionary<string, string> extend = null, string filter1 = "", string filter2 = "")
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Debug ");
                ProcessMessage(sb, module, category, subcategory, message, filter1, filter2);
                ProcessExtend(sb, extend);
                Log.Debug(sb.ToString());
            }
            catch { }
        }
        /// <summary>
        /// error日志
        /// </summary>
        /// <param name="category"></param>
        /// <param name="subcategory"></param>
        /// <param name="message"></param>
        /// <param name="extend"></param>
        public void Error(Exception ex, string module, string category, string subcategory, string message,
            Dictionary<string, string> extend = null, string filter1 = "", string filter2 = "")
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Error ");
                ProcessMessage(sb, module, category, subcategory, message, filter1, filter2);
                ProcessExtend(sb, extend);
                Log.Error(ex, sb.ToString());
            }
            catch { }
        }

        /// <summary>
        /// info日志
        /// </summary>
        /// <param name="category"></param>
        /// <param name="subcategory"></param>
        /// <param name="message"></param>
        /// <param name="extend"></param>
        public void Warning(string category, string module, string subcategory, string message,
            Dictionary<string, string> extend = null, string fliter1 = "", string filter2 = "")
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Warn ");
                ProcessMessage(sb, module, category, subcategory, message, fliter1, filter2);
                ProcessExtend(sb, extend);
                Log.Warning(sb.ToString());
            }
            catch { }
        }

        /// <summary>
        ///处理额外信息
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="extend"></param>
        private void ProcessExtend(StringBuilder sb, Dictionary<string, string> extend)
        {
            if (extend != null && extend.Keys.Count > 0)
            {
                sb.Append(Environment.NewLine);
                int i = extend.Keys.Count;
                int j = 0;
                foreach (var key in extend.Keys)
                {
                    j++;
                    sb.Append($"{key}:{extend[key]}");
                    if (j != i)
                    {
                        sb.Append(Environment.NewLine);
                    }
                }
            }
        }
        /// <summary>
        /// 处理信息
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="module"></param>
        /// <param name="category"></param>
        /// <param name="subcategory"></param>
        /// <param name="message"></param>
        /// <param name="filter1"></param>
        /// <param name="filter2"></param>
        private void ProcessMessage(StringBuilder sb, string module, string category, string subcategory, string message,
            string filter1 = "", string filter2 = "")
        {
            sb.Append($"[{module}]");
            sb.Append($"[{category}]");
            sb.Append($"[{subcategory}]");
            sb.Append($"[{filter1}]");
            sb.Append($"[{filter2}]");
            sb.Append($"{message}");
        }
    }
}
