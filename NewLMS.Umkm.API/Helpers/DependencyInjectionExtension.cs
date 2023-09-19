using Microsoft.Extensions.DependencyInjection;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.Domain.FUSE.GenericRepositoryFuse;
// using NewLMS.Umkm.Domain.Services;
// using NewLMS.Umkm.MediatR.Features.SlikRequestDuplikasis.Commands;
using NewLMS.Umkm.MediatR.Features.RfZipCodes.Commands;

namespace NewLMS.Umkm.Api.Helpers
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            // services.AddScoped<IDuplicationCheckTask, DuplicationCheckTask>();
            services.AddScoped<IRfZipCodesUploadJSON, RfZipCodesUploadJSON>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient(typeof(IGenericRepositoryFuseAsync<>), typeof(GenericRepositoryFuseAsync<>));
            services.AddTransient(typeof(IGenericRepositoryDWHAsync<>), typeof(GenericRepositoryDWHAsync<>));
          
        }
    }
}
