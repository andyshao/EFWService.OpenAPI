using System;
using System.Collections.Generic;
using System.Text;

namespace TongCheng.LiveChat.Utility.Logger
{
    internal interface ILogger
    {
        void Info(string module, string category, string subcategory, string message,
           Dictionary<string, string> extend = null, string filter1 = "", string filter2 = "");

        void Warning(string category, string module, string subcategory, string message,
            Dictionary<string, string> extend = null, string fliter1 = "", string filter2 = "");

        void Error(Exception ex, string module, string category, string subcategory, string message,
             Dictionary<string, string> extend = null, string filter1 = "", string filter2 = "");
        void Debug(string module, string category, string subcategory, string message,
            Dictionary<string, string> extend = null, string filter1 = "", string filter2 = "");
    }
}
