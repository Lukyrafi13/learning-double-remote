using Microsoft.Extensions.DependencyInjection;
using NewLMS.UMKM.Repository.GenericRepository;
using NewLMS.UMKM.Domain.FUSE.GenericRepositoryFuse;
// using NewLMS.UMKM.Domain.Services;
// using NewLMS.UMKM.MediatR.Features.SlikRequestDuplikasis.Commands;
using NewLMS.UMKM.MediatR.Features.RfZipcodes.Commands;

namespace NewLMS.UMKM.Api.Helpers
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
