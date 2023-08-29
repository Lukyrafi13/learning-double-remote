using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewLMS.UMKM.Maps.Delegates;
using NewLMS.UMKM.Maps.Interfaces;
using NewLMS.UMKM.Maps.Models;
using NewLMS.UMKM.Maps.Services;
using Refit;
using System.Reflection;
using System.Text.Json;

namespace NewLMS.UMKM.Maps
{
    public static class ServiceRegistration
    {
        private const string CONFIGURATION_NAME = "Maps";
        public static void AddMapsAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<HttpLoggingHandler>();
            services.AddTransient<AuthHeaderHandler>();
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };

            var settings = new RefitSettings()
            {
                ContentSerializer = new SystemTextJsonContentSerializer(options)
            };
            SalesMonitoringModel option = new SalesMonitoringModel();
            services.Configure<SalesMonitoringModel>(configuration.GetSection(CONFIGURATION_NAME));
            configuration.GetSection(CONFIGURATION_NAME).Bind(option);
            services.AddRefitClient<IApiService>(settings)
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(option.Url);
            })
            .AddHttpMessageHandler<AuthHeaderHandler>()
            .AddHttpMessageHandler<HttpLoggingHandler>();
            services.AddTransient(typeof(IMapService), typeof(MapService));
        }
    }
}