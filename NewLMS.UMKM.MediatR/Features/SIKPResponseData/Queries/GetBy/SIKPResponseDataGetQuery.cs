using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SIKPResponseDatas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.SIKPResponseDatas.Queries
{
    public class SIKPResponseDataGetQuery : SIKPResponseDataFindRequestDto, IRequest<ServiceResponse<SIKPResponseDataResponseDto>>
    {
    }

    public class SIKPResponseDataGetQueryHandler : IRequestHandler<SIKPResponseDataGetQuery, ServiceResponse<SIKPResponseDataResponseDto>>
    {
        private IGenericRepositoryAsync<SIKPResponseData> _SIKPResponseData;
        private readonly IMapper _mapper;

        public SIKPResponseDataGetQueryHandler(IGenericRepositoryAsync<SIKPResponseData> SIKPResponseData, IMapper mapper)
        {
            _SIKPResponseData = SIKPResponseData;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<SIKPResponseDataResponseDto>> Handle(SIKPResponseDataGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "App",
                    "App.BookingOffice",
                    "App.JenisProduk",
                    "App.Prospect",
                    "App.Prospect.SektorEkonomi",
                    "App.Prospect.SubSektorEkonomi",
                    "App.Prospect.SubSubSektorEkonomi",
                    "TipeDebitur",
                    "SektorEkonomi",
                    "SubSektorEkonomi",
                    "SubSubSektorEkonomi",
                    "JenisKelamin",
                    "StatusPernikahan",
                    "PendidikanTerakhir",
                    "DataPekerjaan",
                    "KodePos",
                    "KodePosUsaha",
                    "Linkage",
                    "JenisKelaminSIKP",
                    "StatusPernikahanSIKP",
                    "PendidikanTerakhirSIKP",
                    "DataPekerjaanSIKP",
                    "KodePosUsahaSIKP",
                    "LinkageSIKP",
                };

                var data = await _SIKPResponseData.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<SIKPResponseDataResponseDto>.Return404("Data SIKPResponseData not found");
                var response = _mapper.Map<SIKPResponseDataResponseDto>(data);
                return ServiceResponse<SIKPResponseDataResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SIKPResponseDataResponseDto>.ReturnException(ex);
            }
        }
    }
}