using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewLMS.Umkm.Scoring.Interfaces;
using NewLMS.Umkm.Scoring.Services;
using System;

namespace NewLMS.Umkm.Scoring
{
    public static class ServiceRegistration
    {
        public static void AddScoringService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IScoringService, ScoringService>();
        }
    }
}
