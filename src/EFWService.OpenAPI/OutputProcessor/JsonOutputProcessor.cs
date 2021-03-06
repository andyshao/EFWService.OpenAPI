﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWService.OpenAPI.Utils;

namespace EFWService.OpenAPI.OutputProcessor
{
    public class JsonOutputProcessor : IOutputProcessor
    {
        public string OutPut<RequestModelType>(RequestModelType request, List<string> ingoreList)
        {
            return JsonConvertExd.SerializeObjectWithIgnore(request, ingoreList);
        }
    }
}
