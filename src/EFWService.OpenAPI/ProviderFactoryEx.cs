using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EFWService.OpenAPI
{
    public static class ProviderFactoryEx
    {
        public static void Init(this ValueProviderFactoryCollection valueProviderFactories)
        {
            valueProviderFactories.Clear();
            valueProviderFactories.Add(new FormValueProviderFactory());
            valueProviderFactories.Add(new RouteDataValueProviderFactory());
            valueProviderFactories.Add(new QueryStringValueProviderFactory());
            //valueProviderFactories.Add(new ChildActionValueProviderFactory());
            //valueProviderFactories.Add(new JsonValueProviderFactory());
            //valueProviderFactories.Add(new HttpFileCollectionValueProviderFactory());
        }
    }
}
