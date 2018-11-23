using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace EFWService.OpenAPI.Utils
{
    public static class JsonConvertExd
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ignoreList"></param>
        /// <param name="isJsonProperty">是否使用JsonProperty定义的名称</param>
        /// <param name="datetimeFormater">序列化的时间类型的格式</param>
        /// <returns></returns>
        public static string SerializeObjectWithIgnore(object value, List<string> ignoreList, bool isJsonProperty = true, string datetimeFormater = "yyyy-MM-dd HH:mm:ss.fff")
        {
            if (ignoreList == null || ignoreList.Count <= 0)
            {
                return SerializeObject(value, datetimeFormater);
            }
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new JsonIgnoreContractResolver(ignoreList, isJsonProperty),
                DateFormatString = datetimeFormater,
                Formatting = Formatting.None
            };
            return JsonConvert.SerializeObject(value, settings);
        }
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeObject(this object value, string datetimeFormart = "yyyy-MM-dd HH:mm:ss.fff")
        {
            IsoDateTimeConverter dateC = new IsoDateTimeConverter() { DateTimeFormat = datetimeFormart };
            var formatting = Formatting.None;
            var converters = new JsonConverter[] { dateC };
            JsonSerializerSettings settings = new JsonSerializerSettings { Converters = converters };
            string json = JsonConvert.SerializeObject(value, formatting, settings);
            return json;
        }

        public static T Deserialize<T>(string value, string datetimeFormart = "yyyy-MM-dd HH:mm:ss.fff")
        {
            IsoDateTimeConverter dateC = new IsoDateTimeConverter() { DateTimeFormat = datetimeFormart };
            var converters = new JsonConverter[] { dateC };
            JsonSerializerSettings settings = new JsonSerializerSettings { Converters = converters };
            return JsonConvert.DeserializeObject<T>(value, settings);
        }
    }
}
