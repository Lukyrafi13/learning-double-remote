using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSatuanKapasitass;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSatuanKapasitass.Queries
{
    public class RFSatuanKapasitasGetQuery : RFSatuanKapasitasFindRequestDto, IRequest<ServiceResponse<RFSatuanKapasitasResponseDto>>
    {
    }

    public class RFSatuanKapasitasGetQueryHandler : IRequestHandler<RFSatuanKapasitasGetQuery, ServiceResponse<RFSatuanKapasitasResponseDto>>
    {
        private IGenericRepositoryAsync<RFSatuanKapasitas> _RFSatuanKapasitas;
        private readonly IMapper _mapper;

        public RFSatuanKapasitasGetQueryHandler(IGenericRepositoryAsync<RFSatuanKapasitas> RFSatuanKapasitas, IMapper mapper)
        {
            _RFSatuanKapasitas = RFSatuanKapasitas;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSatuanKapasitasResponseDto>> Handle(RFSatuanKapasitasGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSatuanKapasitas.GetByIdAsync(request.SatuanKapasitas_Id, "SatuanKapasitas_Id");
                if (data == null)
                    return ServiceResponse<RFSatuanKapasitasResponseDto>.Return404("Data RFSatuanKapasitas not found");
                var response = _mapper.Map<RFSatuanKapasitasResponseDto>(data);
                return ServiceResponse<RFSatuanKapasitasResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSatuanKapasitasResponseDto>.ReturnException(ex);
            }
        }
    }
}