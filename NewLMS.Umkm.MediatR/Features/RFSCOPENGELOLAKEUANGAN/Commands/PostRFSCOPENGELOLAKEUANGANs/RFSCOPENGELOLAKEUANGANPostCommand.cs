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
    public class RFSCOPENGELOLAKEUANGANPostCommand : RFSCOPENGELOLAKEUANGANPostRequestDto, IRequest<ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>>
    {

    }
    public class PostRFSCOPENGELOLAKEUANGANCommandHandler : IRequestHandler<RFSCOPENGELOLAKEUANGANPostCommand, ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOPENGELOLAKEUANGAN> _rfScoPENGELOLAKEUANGAN;
        private readonly IMapper _mapper;

        public PostRFSCOPENGELOLAKEUANGANCommandHandler(IGenericRepositoryAsync<RFSCOPENGELOLAKEUANGAN> rfScoPENGELOLAKEUANGAN, IMapper mapper)
        {
            _rfScoPENGELOLAKEUANGAN = rfScoPENGELOLAKEUANGAN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>> Handle(RFSCOPENGELOLAKEUANGANPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var rfScoPENGELOLAKEUANGAN = _mapper.Map<RFSCOPENGELOLAKEUANGAN>(request);

                var returnedRfProduct = await _rfScoPENGELOLAKEUANGAN.AddAsync(rfScoPENGELOLAKEUANGAN, callSave: false);

                // var response = _mapper.Map<RFSCOPENGELOLAKEUANGANResponseDto>(returnedRfProduct);
                var response = _mapper.Map<RFSCOPENGELOLAKEUANGANResponseDto>(returnedRfProduct);

                await _rfScoPENGELOLAKEUANGAN.SaveChangeAsync();
                return ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}