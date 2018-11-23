using EFWService.OpenAPI.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EFWService.OpenAPI.OutputProcessor
{
    public class XmlOutputProcessor : IOutputProcessor
    {
        public string OutPut<RequestModelType>(RequestModelType request,List<string> ingoreList)
        {
            List<string> removeNodes = ingoreList?.Select(x => x.Substring(x.LastIndexOf(".") + 1)).ToList();
            return XmlSerializeExd.CustomXmlSerialize(request, removeNodes?.ToArray());
        }
    }
}
