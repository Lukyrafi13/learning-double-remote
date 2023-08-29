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
    public class AppPemohonPeroranganGet : AppFind, IRequest<ServiceResponse<AppPemohonPeroranganResponse>>
    {
    }

    public class AppPemohonPeroranganGetQueryHandler : IRequestHandler<AppPemohonPeroranganGet, ServiceResponse<AppPemohonPeroranganResponse>>
    {
        private IGenericRepositoryAsync<App> _App;
        private readonly IMapper _mapper;

        public AppPemohonPeroranganGetQueryHandler(IGenericRepositoryAsync<App> App, IMapper mapper)
        {
            _App = App;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AppPemohonPeroranganResponse>> Handle(AppPemohonPeroranganGet request, CancellationToken cancellationToken)
        {

            var includes = new string[]{
                "PendidikanTerakhir",
                "StatusPerkawinan",
                "DataPekerjaan",
                "KodePos",
                "StatusTempatTinggal",
                "KodePosKontakDarurat",
                "DataPekerjaanPasangan",
                "KodePosPasangan",
            };

            var data = await _App.GetByIdAsync(request.Id, "Id", includes);

            var response = _mapper.Map<AppPemohonPeroranganResponse>(data);

            return ServiceResponse<AppPemohonPeroranganResponse>.ReturnResultWith200(response);
        }
    }
}