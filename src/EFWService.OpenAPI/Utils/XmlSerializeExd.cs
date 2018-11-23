using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EFWService.OpenAPI.Utils
{
    /// <summary>
    /// xml序列化
    /// </summary>
    public static class XmlSerializeExd
    {
        /// <summary>
        /// 自定义xml序列化
        /// </summary>
        /// <param name="response"></param>
        /// <param name="removeAllAttributes">移除属性</param>
        /// <param name="removeXsd">移除xsd属性</param>
        /// <param name="removeXsi">移除xsi</param>
        /// <param name="removeNodes">移除节点列表</param>
        /// <param name="head"></param>
        /// <returns></returns>
        public static string CustomXmlSerialize(this object response, string[] removeNodes = null, bool removeAllAttributes = false,
          bool removeXsd = false, bool removeXsi = false, string head = "<?xml version=\"1.0\" encoding=\"utf-8\"?>")
        {
            string xml = string.Empty;
            XmlSerializer ser = new XmlSerializer(response.GetType());

            using (MemoryStream stream = new MemoryStream(100))
            {
                ser.Serialize(stream, response);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    xml = reader.ReadToEnd();
                }
            }

            var xe = XElement.Parse(xml);
            if (removeAllAttributes)
            {
                xe.RemoveAttributes();
            }

            RemoveXsdXsi(removeXsd, removeXsi, xe);

            if (removeNodes != null && removeNodes.Length > 0)
            {
                List<XElement> removeList = new List<XElement>();

                foreach (var item in xe.Elements())
                {
                    if (removeNodes.Contains(item.Name.LocalName))
                    {
                        removeList.Add(item);
                    }
                }
                foreach (var item in removeList)
                {
                    item.Remove();
                }
            }
            return head + System.Environment.NewLine + xe.ToString();
        }

        private static void RemoveXsdXsi(bool removeXsd, bool removeXsi, XElement xe)
        {
            List<XAttribute> rList = new List<XAttribute>();
            foreach (var item in xe.Attributes())
            {
                if (removeXsd && item.Name.LocalName == "xsd")
                {
                    rList.Add(item);
                }
                if (removeXsi && item.Name.LocalName == "xsi")
                {
                    rList.Add(item);
                }
            }
            foreach (var item in rList)
            {
                item.Remove();
            }
        }
        /// <summary>
        /// xml反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T XmlDeserialize<T>(this string s)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(s);
            XmlNodeReader reader = new XmlNodeReader(xdoc.DocumentElement);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            object obj = ser.Deserialize(reader);
            return (T)obj;
        }
    }
}
