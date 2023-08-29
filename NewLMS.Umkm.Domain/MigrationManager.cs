using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewLMS.UMKM.Domain.Context;

namespace NewLMS.UMKM.Domain
{
	public static class MigrationManager
	{
		public static IHost ExecuteMigration(this IHost host)
		{
            using var scope = host.Services.CreateScope();
            using (var appContext = scope.ServiceProvider.GetRequiredService<UserContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return host;
        }
	}
}

