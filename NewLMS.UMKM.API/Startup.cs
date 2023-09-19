using NewLMS.Umkm.Api.Helpers;
using NewLMS.Umkm.API.Helpers.Mapping;
using NewLMS.Umkm.MediatR.PipeLineBehavior;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;
using NewLMS.Umkm.API.Middlewares;
using Bjb.DigitalBisnis.SLIK;
using NewLMS.Umkm.Domain.Dwh;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Bjb.Util.GeneratePdf;
using NewLMS.Umkm.Scoring;
using bjb.util.uim;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Bjb.DigitalBisnis.FcmNotification;
using Hangfire;
using Hangfire.SqlServer;
using NewLMS.Umkm.API.Filters;
using NewLMS.Umkm.Maps;
using NewLMS.Umkm.Domain.FUSE;
using NewLMS.Umkm.Domain.Context;
using Bjb.DigitalBisnis.CoreBanking;
using NewLMS.Umkm.DomainDHN;
using Bjb.DigitalBisnis.DigiloanAPI;
using Bjb.DigitalBisnis.BaseMvcApi;
using Bjb.DigitalBisnis.CurrentUser;
using Bjb.DigitalBisnis.HealthCheck;
using NewLMS.Umkm.Data.Dto.AppSettingJson;
using NewLMS.Umkm.FileUpload;
using NewLMS.Umkm.SIKP;
using NewLMS.Umkm.SIKP2;
using Bjb.DigitalBisnis.Consul;

namespace NewLMS.Umkm.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            BuildAppSettingsProvider();
            var assembly = AppDomain.CurrentDomain.Load("NewLMS.Umkm.MediatR");
            services.AddMediatR(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssemblies(Enumerable.Repeat(assembly, 1));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContextPool<UserContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("UserDbConnectionString")
                    , p =>
                    {
                        p.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    })
                .LogTo(
                    Console.WriteLine,
                    LogLevel.Debug,
                    DbContextLoggerOptions.DefaultWithLocalTime | DbContextLoggerOptions.SingleLine
                )
                .EnableSensitiveDataLogging();
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddBaseMvcApiExtension(Configuration, typeof(Startup), "LMS UMKM Web API");
            services.AddSingleton(MapperConfig.GetMapperConfigs());
            services.AddDependencyInjection();
            services.AddSignalR();
            services.AddConsulConfig(Configuration);
            services.AddFileUploadAPI(Configuration);
            services.AddServiceHealthCheck(Configuration);
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
            services.AddSlickService(Configuration);
            services.AddPersistenceDWH(Configuration);
            services.AddPersistenceFUSE(Configuration);
            services.AddPersistenceDHN(Configuration);
            services.AddPdfService(Configuration);
            services.AddScoringService(Configuration);
            services.AddTechRedemptionUtilUim(Configuration);
            services.AddFCMNotification(Configuration);
            services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                DisableGlobalLocks = true
            }));

            // Add the processing server as IHostedService
            services.AddHangfireServer();
            services.AddMapsAPI(Configuration);
            services.AddCoreBankinAPI(Configuration);
            services.AddDigiloanAPI(Configuration);
            services.AddSIKPAPI(Configuration);
            services.AddSIKPAPI2(Configuration);
            services.AddCurrentUserExtension(Configuration);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseBaseMvcApiExtension(env, provider, Configuration);
            app.UseExceptionMiddleware();
            app.UseExceptionMiddleware();
            app.UseConsul(Configuration);
            app.UseHealthCheck(env,Configuration);
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new HangfireAuthorizeFilter() }
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "AdminAreaRoute",
                    areaName: "Admin",
                    pattern: "admin/{controller:slugify=Dashboard}/{action:slugify=Index}/{id:slugify?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller:slugify}/{action:slugify}/{id:slugify?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

        private void BuildAppSettingsProvider()
        {
            AppSettingJsonDto.HostFrontEnd = Configuration["HostFrontEnd"];
        }
    }
}
