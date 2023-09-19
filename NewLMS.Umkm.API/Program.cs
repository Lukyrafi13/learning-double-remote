using System;
using System.IO;
using Elastic.Apm.SerilogEnricher;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using NewLMS.Umkm.Domain;

namespace NewLMS.Umkm.API
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
       .Build();

        static string rootDir => Configuration.GetValue<string>("FileStorage:Mode") switch
        {
            "Local" => Configuration.GetValue<string>("FileStorage:Local:Directory"),
            _ => throw new NotSupportedException()
        };

        public static void Main(string[] args)
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.WithElasticApmCorrelationInfo()
                    .CreateLogger();
                CreateHostBuilder(args)
                .Build()
                .ExecuteMigration()
                .Run();
            }
            catch (Exception exception)
            {
                Log.Error(exception, exception.Message.ToString());
                throw new Exception(exception.Message.ToString());
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               })
               .UseSerilog();

    }
}
