using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWService.OpenAPI.Models;

namespace EFWService.OpenAPI.Utils
{
    public class CheckResultFuns
    {
        public Func<bool> Funs { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class ParamsCheckHelper
    {
        private List<RequestParamsCheckResult> checkResultList = new List<RequestParamsCheckResult>();
        private List<CheckResultFuns> checkResultFunsList = new List<CheckResultFuns>();
        private Action next = null;

        public ParamsCheckHelper Check(Func<bool> checkFunc, string errorMessage)
        {
            checkResultFunsList.Add(new CheckResultFuns() { Funs = checkFunc, ErrorMessage = errorMessage });
            return this;
        }
        /// <summary>
        /// 检查完参数后执行，保留最后一次调用Action
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public ParamsCheckHelper Then(Action action)
        {
            this.next = action;
            return this;
        }

        public RequestParamsCheckResult Finish()
        {
            foreach (var item in checkResultFunsList)
            {
                if (item.Funs() == false)
                {
                    return new RequestParamsCheckResult() { Success = false, ErrorMessage = item.ErrorMessage };
                }
            }
            if (next != null)
            {
                next();
            }
            return new RequestParamsCheckResult() { Success = true };
        }
    }
}
