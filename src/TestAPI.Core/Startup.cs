using EFWService.Core.OpenAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Buffers;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TestAPI.Core
{
    public class Startup
    {
        public IConfigurationRoot Configuration;
        public Startup()
        {
            var builder = new ConfigurationBuilder().
                AddJsonFile("appsettings.json", false, true);
            Configuration = builder.Build();

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOpenAPI();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            logger.AddConsole();
            app.UseOpenAPI();
        }
    }
}
