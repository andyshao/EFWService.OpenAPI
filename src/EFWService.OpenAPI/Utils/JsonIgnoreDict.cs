using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace EFWService.OpenAPI.Utils
{
    /// <summary>
    /// 返回结果处理
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public class ResultIgnoreSource<TSource>
    {
        private List<string> ignoreList = new List<string>();
        /// <summary>
        /// 返回字段排查
        /// </summary>
        public List<string> IgnoreList
        {
            get
            {
                return ignoreList;
            }
        }
        /// <summary>
        /// 排除字段
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="express"></param>
        /// <returns></returns>
        public ResultIgnoreSource<TSource> Ignore<TProperty>(Expression<Func<TSource, TProperty>> express)
        {
            if (express == null)
            {
                throw new ArgumentNullException("express");
            }
            MemberExpression memberExpression = express.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("请为类型 \"" + typeof(TSource).FullName + "\" 的指定一个字段（Field）或属性（Property）作为 Lambda 的主体（Body）。");
            }
            //获取命名空间+名称
            string fullName = memberExpression.Member.DeclaringType.FullName + "." + memberExpression.Member.Name;
            if (!ignoreList.Contains(fullName))
            {
                ignoreList.Add(fullName);
            }
            return this;
        }
    }
}
