using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using NewLMS.Umkm.Data.Dto.RFSCOPENGELOLAKEUANGANs;

namespace NewLMS.Umkm.MediatR.Features.RFSCOPENGELOLAKEUANGANs.Commands
{
    public class RFSCOPENGELOLAKEUANGANPutCommand : RFSCOPENGELOLAKEUANGANPutRequestDto, IRequest<ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>>
    {
    }

    public class PutRFSCOPENGELOLAKEUANGANCommandHandler : IRequestHandler<RFSCOPENGELOLAKEUANGANPutCommand, ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOPENGELOLAKEUANGAN> _rfScoPENGELOLAKEUANGAN;
        private readonly IMapper _mapper;

        public PutRFSCOPENGELOLAKEUANGANCommandHandler(IGenericRepositoryAsync<RFSCOPENGELOLAKEUANGAN> rfScoPENGELOLAKEUANGAN, IMapper mapper)
        {
            _rfScoPENGELOLAKEUANGAN = rfScoPENGELOLAKEUANGAN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>> Handle(RFSCOPENGELOLAKEUANGANPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSCOPENGELOLAKEUANGAN = await _rfScoPENGELOLAKEUANGAN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                existingRFSCOPENGELOLAKEUANGAN.SCO_CODE = request.SCO_CODE;
                existingRFSCOPENGELOLAKEUANGAN.SCO_DESC = request.SCO_DESC;
                existingRFSCOPENGELOLAKEUANGAN.CORE_CODE = request.CORE_CODE;
                existingRFSCOPENGELOLAKEUANGAN.ACTIVE = request.ACTIVE;

                await _rfScoPENGELOLAKEUANGAN.UpdateAsync(existingRFSCOPENGELOLAKEUANGAN);

                var response = _mapper.Map<RFSCOPENGELOLAKEUANGANResponseDto>(existingRFSCOPENGELOLAKEUANGAN);

                return ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}