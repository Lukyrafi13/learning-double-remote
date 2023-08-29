using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewLMS.UMKM.Scoring.Interfaces;
using NewLMS.UMKM.Scoring.Services;
using System;

namespace NewLMS.UMKM.Scoring
{
    public static class ServiceRegistration
    {
        public static void AddScoringService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IScoringService, ScoringService>();
        }
    }
}
