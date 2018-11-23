using EFWService.Core.OpenAPI.OutputProcessor;
using EFWService.Core.OpenAPI.Utils;
using System.Collections.Generic;

namespace EFWService.Core.OpenAPI.OutputProcessor
{
    public class JsonOutputProcessor : IOutputProcessor
    {
        public string OutPut<ResponseModel>(ResponseModel model, List<string> ingoreList)
        {
            return JsonConvertExd.SerializeObjectWithIgnore(model, ingoreList);
        }
    }
}
