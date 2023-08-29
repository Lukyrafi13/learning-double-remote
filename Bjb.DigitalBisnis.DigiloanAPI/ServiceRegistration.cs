using Bjb.DigitalBisnis.DigiloanAPI.Delegates;
using Bjb.DigitalBisnis.DigiloanAPI.Interfaces;
using Bjb.DigitalBisnis.DigiloanAPI.Models;
using Bjb.DigitalBisnis.DigiloanAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Text.Json;

namespace Bjb.DigitalBisnis.DigiloanAPI
{
    public static class ServiceRegistration
    {
        private const string CONFIGURATION_NAME = "Digiloan";
        public static void AddDigiloanAPI(this IServiceCollection services, IConfiguration configuration)
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
            DigiloanModel option = new DigiloanModel();
            services.Configure<DigiloanModel>(configuration.GetSection(CONFIGURATION_NAME));
            configuration.GetSection(CONFIGURATION_NAME).Bind(option);
            services.AddRefitClient<IApiService>(settings)
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(option.Url);
            })
            .AddHttpMessageHandler<AuthHeaderHandler>()
            .AddHttpMessageHandler<HttpLoggingHandler>();
            services.AddTransient<IDigiloanService, DigiloanService>();
        }
    }
}