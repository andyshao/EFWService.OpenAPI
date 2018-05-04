using Microsoft.Extensions.DependencyInjection;
using EFWService.Core.OpenAPI.DynamicController;

namespace EFWService.Core.OpenAPI
{
    public static class OpenAPIExtension
    {
        public static IMvcBuilder AddOpenAPI(this IMvcBuilder builder)
        {
            Bootstrapper.Initialize(builder);
            return builder;
        }
    }
}
