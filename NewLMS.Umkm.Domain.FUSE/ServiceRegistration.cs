using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewLMS.UMKM.Domain.FUSE.Context;
using NewLMS.UMKM.Domain.FUSE.Services;

namespace NewLMS.UMKM.Domain.FUSE;
public static class ServiceRegistration
{
    private const string DEFAULT_CONNECTION_STRING = "FUSEDbConnectionString";

    public static void AddPersistenceFUSE(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FUSEContext>(options =>
           options.UseSqlServer
           (
               configuration.GetConnectionString(DEFAULT_CONNECTION_STRING),
               b => b.MigrationsAssembly(typeof(FUSEContext).Assembly.FullName)
           )
       );
        services.AddTransient<ISBDKService, SBDKService>();
        services.AddTransient<IBMPKService, BMPKService>();
    }
}