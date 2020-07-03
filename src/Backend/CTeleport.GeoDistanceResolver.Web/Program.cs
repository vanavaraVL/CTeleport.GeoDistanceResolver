using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace CTeleport.GeoDistanceResolver.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            ConfigureDefaultHostBuilder(args)
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });

        private static IHostBuilder ConfigureDefaultHostBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args);

            // content root
            host.UseContentRoot(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath));

            // configure settings
            host.ConfigureAppConfiguration(
                configurationBuilder =>
                {
                    configurationBuilder.SetBasePath(
                        Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath));

                    configurationBuilder.AddJsonFile(
                        "Appsettings/appsettings.json",
                        optional: false,
                        reloadOnChange: true);

                    configurationBuilder.AddEnvironmentVariables();

                    configurationBuilder
                        .Build();
                }
            );

            // configure logging
            host.ConfigureLogging(
                (hostingContext, logging) =>
                {
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .CreateLogger();

                    logging.AddSerilog(Log.Logger, true);
                }
            );

            host.UseSerilog();
            
            return host;
        }
    }
}
