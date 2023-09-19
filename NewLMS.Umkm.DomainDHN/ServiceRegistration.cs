using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewLMS.Umkm.DomainDHN.Context;

namespace NewLMS.Umkm.DomainDHN
{
    public static class ServiceRegistration
    {
        private const string DEFAULT_CONNECTION_STRING = "DHNDbConnectionString";

        public static void AddPersistenceDHN(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DHNContext>(options =>
               options.UseNpgsql
               (
                   configuration.GetConnectionString(DEFAULT_CONNECTION_STRING),
                   b => b.MigrationsAssembly(typeof(DHNContext).Assembly.FullName)
               ).UseLowerCaseNamingConvention()

           );
        }
    }
}