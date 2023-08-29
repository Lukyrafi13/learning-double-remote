using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSatuanKapasitass;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSatuanKapasitass.Commands
{
    public class RFSatuanKapasitasPutCommand : RFSatuanKapasitasPutRequestDto, IRequest<ServiceResponse<RFSatuanKapasitasResponseDto>>
    {
    }

    public class PutRFSatuanKapasitasCommandHandler : IRequestHandler<RFSatuanKapasitasPutCommand, ServiceResponse<RFSatuanKapasitasResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSatuanKapasitas> _RFSatuanKapasitas;
        private readonly IMapper _mapper;

        public PutRFSatuanKapasitasCommandHandler(IGenericRepositoryAsync<RFSatuanKapasitas> RFSatuanKapasitas, IMapper mapper)
        {
            _RFSatuanKapasitas = RFSatuanKapasitas;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSatuanKapasitasResponseDto>> Handle(RFSatuanKapasitasPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSatuanKapasitas = await _RFSatuanKapasitas.GetByIdAsync(request.SatuanKapasitas_Id, "SatuanKapasitas_Id");
                existingRFSatuanKapasitas.SatuanKapasitas_Id = request.SatuanKapasitas_Id;
                existingRFSatuanKapasitas.SatuanKapasitas_Desc = request.SatuanKapasitas_Desc;

                await _RFSatuanKapasitas.UpdateAsync(existingRFSatuanKapasitas);

                var response = _mapper.Map<RFSatuanKapasitasResponseDto>(existingRFSatuanKapasitas);

                return ServiceResponse<RFSatuanKapasitasResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSatuanKapasitasResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}