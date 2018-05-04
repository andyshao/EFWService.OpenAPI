using EFWService.Core.OpenAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace TestAPI.Core
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option =>
            {
                //option.ValueProviderFactories.Init();
            }).AddOpenAPI();
            //GlobalHost.Builder.Populate(services);
            //return new AutofacServiceProvider(GlobalHost.Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "TestQuery",
                   template: "api/query/{action}",
                   defaults: new { controller = "TestQuery", action = "Index", ResultType = "json" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=home}/{action=index}",
                    defaults: new { ResultType = "json" });
            });
        }
    }
}
