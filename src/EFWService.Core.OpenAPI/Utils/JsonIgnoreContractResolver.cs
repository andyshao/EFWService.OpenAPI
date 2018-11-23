using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace EFWService.Core.OpenAPI.Utils
{
    /// <summary>
    /// json生成契约
    /// </summary>
	public class JsonIgnoreContractResolver : DefaultContractResolver
    {
        private List<string> ignoreList;
        /// <summary>
        /// 是否使用自定义attribute
        /// </summary>
        private bool isJsonProperty;
        /// <summary>
        /// 生成契约
        /// </summary>
        /// <param name="ignoreList"></param>
        /// <param name="isJsonProperty">是否使用JsonProperty</param>
        public JsonIgnoreContractResolver(List<string> ignoreList, bool isJsonProperty = true)
            : base()
        {
            this.ignoreList = ignoreList;
            this.isJsonProperty = isJsonProperty;
        }
        /// <summary>
        /// 创建接送 JsonProperty
        /// </summary>
        /// <param name="member"></param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        protected override JsonProperty CreateProperty(System.Reflection.MemberInfo member, Newtonsoft.Json.MemberSerialization memberSerialization)
        {
            var jsp = base.CreateProperty(member, memberSerialization);
            //是否使用JsonProperty的名称，不适用的话直接使用属性的名称
            if (!isJsonProperty)
            {
                jsp.PropertyName = member.Name;
            }
            if (ignoreList != null && ignoreList.Count > 0)
            {
                string fieldName = member.DeclaringType + "." + member.Name;
                jsp.Ignored = ignoreList.Contains(fieldName);
            }
            return jsp;
        }
    }
}
