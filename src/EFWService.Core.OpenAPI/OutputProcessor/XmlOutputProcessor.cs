using System.IO;
using System.Text;
using System.Xml.Serialization;
using EFWService.Core.OpenAPI.OutputProcessor;
using EFWService.Core.OpenAPI.Exs;
using System.Collections.Generic;
using System.Linq;

namespace EFWService.Core.OpenAPI.OutputProcessor
{
    public class XmlOutputProcessor : IOutputProcessor
    {
        public string OutPut<ResponseModel>(ResponseModel model, List<string> ingoreList)
        {
            string[] removeNodes = ingoreList?.Select(x => x.Substring(x.LastIndexOf(".") + 1))?.ToArray();
            return XmlSerializeEx.CustomXmlSerialize(model, removeNodes, removeXsd: true, removeXsi: true);
        }
    }
}
