using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFVEHCLASSs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFVEHCLASSs.Commands
{
    public class RFVEHCLASSPutCommand : RFVEHCLASSPutRequestDto, IRequest<ServiceResponse<RFVEHCLASSResponseDto>>
    {
    }

    public class PutRFVEHCLASSCommandHandler : IRequestHandler<RFVEHCLASSPutCommand, ServiceResponse<RFVEHCLASSResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFVEHCLASS> _RFVEHCLASS;
        private readonly IMapper _mapper;

        public PutRFVEHCLASSCommandHandler(IGenericRepositoryAsync<RFVEHCLASS> RFVEHCLASS, IMapper mapper){
            _RFVEHCLASS = RFVEHCLASS;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFVEHCLASSResponseDto>> Handle(RFVEHCLASSPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFVEHCLASS = await _RFVEHCLASS.GetByIdAsync(request.VCLS_CODE, "VCLS_CODE");
                existingRFVEHCLASS.VCLS_CODE = request.VCLS_CODE;
                existingRFVEHCLASS.VCLS_DESC = request.VCLS_DESC;
                existingRFVEHCLASS.CORE_CODE = request.CORE_CODE;
                existingRFVEHCLASS.ACTIVE = request.ACTIVE;
                existingRFVEHCLASS.VEH_CODE = request.VEH_CODE;
                existingRFVEHCLASS.VEHMDL_CODE = request.VEHMDL_CODE;
                
                await _RFVEHCLASS.UpdateAsync(existingRFVEHCLASS);

                var response = _mapper.Map<RFVEHCLASSResponseDto>(existingRFVEHCLASS);

                return ServiceResponse<RFVEHCLASSResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFVEHCLASSResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}