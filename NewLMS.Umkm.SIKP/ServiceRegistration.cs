﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewLMS.Umkm.SIKP.Delegates;
using NewLMS.Umkm.SIKP.Interfaces;
using NewLMS.Umkm.SIKP.Models;
using NewLMS.Umkm.SIKP.Services;
using Refit;
using System.Reflection;
using System.Text.Json;

namespace NewLMS.Umkm.SIKP
{
    public static class ServiceRegistration
    {
        private const string CONFIGURATION_NAME = "SIKP";
        public static void AddSIKPAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<HttpLoggingHandler>();
            // services.AddTransient<AuthHeaderHandler>();
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };

            var settings = new RefitSettings()
            {
                ContentSerializer = new SystemTextJsonContentSerializer(options)
            };
            SIKPModel option = new SIKPModel();
            services.Configure<SIKPModel>(configuration.GetSection(CONFIGURATION_NAME));
            configuration.GetSection(CONFIGURATION_NAME).Bind(option);
            services.AddRefitClient<IApiService>(settings)
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(option.Url);
            })
            // .AddHttpMessageHandler<AuthHeaderHandler>()
            .AddHttpMessageHandler<HttpLoggingHandler>();
            services.AddTransient(typeof(ISIKPService), typeof(SIKPService));
        }
    }
}