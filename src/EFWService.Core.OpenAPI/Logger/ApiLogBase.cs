using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFWService.Core.OpenAPI.Logger
{
    /// <summary>
    /// 日志消息
    /// </summary>
    public class LogMessageItem
    {
        public LogMessageItem()
        {
            LogTime = DateTime.Now;
        }
        public string Message { get; set; }
        public DateTime LogTime { get; private set; }
        public int LogIndex { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", "  ", Message, "\n");
        }
    }
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// info
        /// </summary>
        Info = 1,
        /// <summary>
        /// Warning
        /// </summary>
        Warning = 2,
        /// <summary>
        /// 调试日志
        /// </summary>
        Debug = 3,
        /// <summary>
        /// 异常
        /// </summary>
        Error = 4
    }
    /// <summary>
    /// 日志实体
    /// </summary>
    public class ApiLogEntity
    {

        private List<LogMessageItem> LogMessageItemList { get; set; } = new List<LogMessageItem>();
        private static readonly object lockObj = new object();
        private int logIndex = 0;
        /// <summary>
        /// 模块
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// 大分类
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 小分类
        /// </summary>
        public string SubcategoryName { get; set; }

        /// <summary>
        /// 日志主要消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 搜索条件1
        /// </summary>
        public string TextBoxFilterItem2 { get; set; }

        /// <summary>
        /// 搜索条件2
        /// </summary>
        public string TextBoxFilterItem1 { get; set; }

        /// <summary>
        /// 显示杂项
        /// </summary>
        public Dictionary<string, string> DisplayItems { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 执行时间
        /// </summary>
        public long ElapsedMilliseconds { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        public LogType LogType { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string RequestURL { get; set; }
        /// <summary>
        /// 请求方式
        /// </summary>
        public string HttpMethod { get; set; }
        /// <summary>
        /// 请求body
        /// </summary>
        public string Params { get; set; }
        /// <summary>
        /// 异常
        /// </summary>
        public Exception Exception { get; set; }
        /// <summary>
        /// 异常id
        /// </summary>
        public string ExceptionId { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public string RespContent { get; set; }
        /// <summary>
        /// 请求ip列表
        /// </summary>
        public List<string> ClientIPList { get; set; }

        /// <summary>
        /// 增加日志内容
        /// </summary>
        /// <param name="message"></param>
        public void AddLogMessage(string message)
        {
            lock (lockObj)
            {
                logIndex++;
                LogMessageItemList.Add(new LogMessageItem() { Message = message, LogIndex = logIndex });
            }
        }

        private bool logFinished = false;
        /// <summary>
        /// 结束日志
        /// </summary>
        public void LogFinish()
        {
            try
            {
                lock (lockObj)
                {
                    if (logFinished)
                    {
                        return;
                    }
                    DisplayItems.Add("Url", RequestURL);
                    DisplayItems.Add("Method", HttpMethod);
                    DisplayItems.Add("ES", ElapsedMilliseconds.ToString());
                    if (ClientIPList != null)
                    {
                        DisplayItems.Add("CIP", string.Join(",", ClientIPList));
                    }
                    if (!string.IsNullOrWhiteSpace(Params))
                    {
                        Message += $"\n请求参数:\n  {Params}";
                    }
                    bool isNewLine = true;
                    if (LogMessageItemList != null && LogMessageItemList.Count > 0)
                    {
                        isNewLine = false;
                        Message += $"\n其他信息:\n{string.Join("", LogMessageItemList.OrderBy(x => x.LogIndex))}";
                    }
                    //if (RespContent.Length > 2000)
                    //{
                    //    RespContent = RespContent.Substring(0, 2000);
                    //}
                    Message += (isNewLine ? "\n" : string.Empty) + $"返回参数:\n  {RespContent}";
                    logFinished = true;
                }
            }
            catch { }
        }
    }
}
