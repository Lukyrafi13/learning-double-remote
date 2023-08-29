using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJumlahPegawais;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFJumlahPegawais.Queries
{
    public class RFJumlahPegawaiGetQuery : RFJumlahPegawaiFindRequestDto, IRequest<ServiceResponse<RFJumlahPegawaiResponseDto>>
    {
    }

    public class RFJumlahPegawaiGetQueryHandler : IRequestHandler<RFJumlahPegawaiGetQuery, ServiceResponse<RFJumlahPegawaiResponseDto>>
    {
        private IGenericRepositoryAsync<RFJumlahPegawai> _RFJumlahPegawai;
        private readonly IMapper _mapper;

        public RFJumlahPegawaiGetQueryHandler(IGenericRepositoryAsync<RFJumlahPegawai> RFJumlahPegawai, IMapper mapper)
        {
            _RFJumlahPegawai = RFJumlahPegawai;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFJumlahPegawaiResponseDto>> Handle(RFJumlahPegawaiGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFJumlahPegawai.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                if (data == null)
                    return ServiceResponse<RFJumlahPegawaiResponseDto>.Return404("Data RFJumlahPegawai not found");
                var response = _mapper.Map<RFJumlahPegawaiResponseDto>(data);
                return ServiceResponse<RFJumlahPegawaiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJumlahPegawaiResponseDto>.ReturnException(ex);
            }
        }
    }
}