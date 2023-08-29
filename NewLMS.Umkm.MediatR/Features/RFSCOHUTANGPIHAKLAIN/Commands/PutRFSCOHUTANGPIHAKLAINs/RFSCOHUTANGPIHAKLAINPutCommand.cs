using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOHUTANGPIHAKLAINs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOHUTANGPIHAKLAINs.Commands
{
    public class RFSCOHUTANGPIHAKLAINPutCommand : RFSCOHUTANGPIHAKLAINPutRequestDto, IRequest<ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>>
    {
    }

    public class PutRFSCOHUTANGPIHAKLAINCommandHandler : IRequestHandler<RFSCOHUTANGPIHAKLAINPutCommand, ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOHUTANGPIHAKLAIN> _RFSCOHUTANGPIHAKLAIN;
        private readonly IMapper _mapper;

        public PutRFSCOHUTANGPIHAKLAINCommandHandler(IGenericRepositoryAsync<RFSCOHUTANGPIHAKLAIN> RFSCOHUTANGPIHAKLAIN, IMapper mapper){
            _RFSCOHUTANGPIHAKLAIN = RFSCOHUTANGPIHAKLAIN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>> Handle(RFSCOHUTANGPIHAKLAINPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSCOHUTANGPIHAKLAIN = await _RFSCOHUTANGPIHAKLAIN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                existingRFSCOHUTANGPIHAKLAIN.SCO_CODE = request.SCO_CODE;
                existingRFSCOHUTANGPIHAKLAIN.SCO_DESC = request.SCO_DESC;
                existingRFSCOHUTANGPIHAKLAIN.CORE_CODE = request.CORE_CODE;
                existingRFSCOHUTANGPIHAKLAIN.ACTIVE = request.ACTIVE;
                
                await _RFSCOHUTANGPIHAKLAIN.UpdateAsync(existingRFSCOHUTANGPIHAKLAIN);

                var response = _mapper.Map<RFSCOHUTANGPIHAKLAINResponseDto>(existingRFSCOHUTANGPIHAKLAIN);

                return ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}