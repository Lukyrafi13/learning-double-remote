﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewLMS.Umkm.FileUpload.Delegates;
using NewLMS.Umkm.FileUpload.Interfaces;
using NewLMS.Umkm.FileUpload.Models;
using NewLMS.Umkm.FileUpload.Services;
using Refit;
using System.Text.Json;

namespace NewLMS.Umkm.FileUpload
{
    public static class ServiceRegistration
    {
        private const string CONFIGURATION_NAME = "FileUpload";
        public static void AddFileUploadAPI(this IServiceCollection services, IConfiguration configuration)
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
            FileUploadModel option = new FileUploadModel();
            services.Configure<FileUploadModel>(configuration.GetSection(CONFIGURATION_NAME));
            configuration.GetSection(CONFIGURATION_NAME).Bind(option);
            services.AddRefitClient<IApiService>(settings)
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(option.Url);
            })
            .AddHttpMessageHandler<AuthHeaderHandler>()
            .AddHttpMessageHandler<HttpLoggingHandler>();
            services.AddTransient(typeof(IUploadService), typeof(UploadService));
        }
    }
}