using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NewLMS.Umkm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Test
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(configurationBuilder =>
            {
                var integrationConfig = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables()
                    .Build();

                configurationBuilder.AddConfiguration(integrationConfig);
            });

            builder.ConfigureServices((builder, services) =>
            {
                services
                    .Remove<DbContextOptions<UserContext>>()
                    .AddDbContext<UserContext>((sp, options) =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbConnectionString"),
                            builder => builder.MigrationsAssembly(typeof(UserContext).Assembly.FullName)));
            });
        }
    }
}
