using EFWService.Core.OpenAPI.DynamicController;
using EFWService.Core.OpenAPI.Formater;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EFWService.Core.OpenAPI
{
    public static class OpenAPIExtension
    {
        public static IServiceCollection AddOpenAPI(this IServiceCollection sc)
        {
            var builder = sc
                .AddRouting()
                .AddControllers(option =>
                {
                    option.ValueProviderFactories.Clear();
                    option.InputFormatters.Clear();
                    option.OutputFormatters.Clear();
                    option.OutputFormatters.Add(new APIOutputFormatter());
                });
            Bootstrapper.Initialize(builder);
            return sc;
        }

        public static IApplicationBuilder UseOpenAPI(this IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(config =>
            {
                config.MapDefaultControllerRoute();
            });
            return app;
        }
    }
}
