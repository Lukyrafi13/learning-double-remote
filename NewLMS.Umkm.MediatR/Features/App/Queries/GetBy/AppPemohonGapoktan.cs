using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Apps;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Apps.Queries
{
    public class AppPemohonGapoktanGet : AppFind, IRequest<ServiceResponse<AppPemohonGapoktanResponse>>
    {
    }

    public class AppPemohonGapoktanGetQueryHandler : IRequestHandler<AppPemohonGapoktanGet, ServiceResponse<AppPemohonGapoktanResponse>>
    {
        private IGenericRepositoryAsync<App> _App;
        private readonly IMapper _mapper;

        public AppPemohonGapoktanGetQueryHandler(IGenericRepositoryAsync<App> App, IMapper mapper)
        {
            _App = App;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AppPemohonGapoktanResponse>> Handle(AppPemohonGapoktanGet request, CancellationToken cancellationToken)
        {

            var includes = new string[]{
                "StatusPerkawinanKetua",
                "PendidikanTerakhirKetua",
                "KodePosKetua",
                "StatusPerkawinanBendahara",
                "PendidikanTerakhirBendahara",
                "KodePosBendahara",
            };

            var data = await _App.GetByIdAsync(request.Id, "Id", includes);

            var response = _mapper.Map<AppPemohonGapoktanResponse>(data);

            return ServiceResponse<AppPemohonGapoktanResponse>.ReturnResultWith200(response);
        }
    }
}