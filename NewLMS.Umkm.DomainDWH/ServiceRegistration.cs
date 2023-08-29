using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewLMS.Umkm.Domain.Dwh.Context;
using NewLMS.Umkm.Domain.Dwh.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Domain.Dwh
{
    public static class ServiceRegistration
    {
        private const string DEFAULT_CONNECTION_STRING = "DwhDbConnectionString";

        public static void AddPersistenceDWH(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DWHContext>(options =>
               options.UseSqlServer
               (
                   configuration.GetConnectionString(DEFAULT_CONNECTION_STRING),
                   b => b.MigrationsAssembly(typeof(DWHContext).Assembly.FullName)
               )

           );
            #region Repositories
            services.AddTransient<IDWHService, DWHService>();
            #endregion
        }
    }
}
