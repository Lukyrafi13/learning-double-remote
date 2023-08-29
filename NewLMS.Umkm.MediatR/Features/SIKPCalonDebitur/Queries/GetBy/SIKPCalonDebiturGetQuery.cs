using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SIKPCalonDebiturs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SIKPCalonDebiturs.Queries
{
    public class SIKPCalonDebiturGetQuery : SIKPCalonDebiturFindRequestDto, IRequest<ServiceResponse<SIKPCalonDebiturResponseDto>>
    {
    }

    public class SIKPCalonDebiturGetQueryHandler : IRequestHandler<SIKPCalonDebiturGetQuery, ServiceResponse<SIKPCalonDebiturResponseDto>>
    {
        private IGenericRepositoryAsync<SIKPCalonDebitur> _SIKPCalonDebitur;
        private readonly IMapper _mapper;

        public SIKPCalonDebiturGetQueryHandler(IGenericRepositoryAsync<SIKPCalonDebitur> SIKPCalonDebitur, IMapper mapper)
        {
            _SIKPCalonDebitur = SIKPCalonDebitur;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<SIKPCalonDebiturResponseDto>> Handle(SIKPCalonDebiturGetQuery request, CancellationToken cancellationToken)
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

                var data = await _SIKPCalonDebitur.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<SIKPCalonDebiturResponseDto>.Return404("Data SIKPCalonDebitur not found");
                var response = _mapper.Map<SIKPCalonDebiturResponseDto>(data);
                return ServiceResponse<SIKPCalonDebiturResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SIKPCalonDebiturResponseDto>.ReturnException(ex);
            }
        }
    }
}