using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace TestAPI.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IHost BuildWebHost(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder =>
            {
                builder.ConfigureLogging((context, builder) =>
                {
                    builder.ClearProviders();
                    builder.AddConsole();
                }).UseStartup<Startup>(); ;
            }).Build();
    }
}
