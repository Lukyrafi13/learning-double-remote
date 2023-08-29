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
    public class RFSCOHUTANGPIHAKLAINPostCommand : RFSCOHUTANGPIHAKLAINPostRequestDto, IRequest<ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>>
    {

    }
    public class PostRFSCOHUTANGPIHAKLAINCommandHandler : IRequestHandler<RFSCOHUTANGPIHAKLAINPostCommand, ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOHUTANGPIHAKLAIN> _RFSCOHUTANGPIHAKLAIN;
        private readonly IMapper _mapper;

        public PostRFSCOHUTANGPIHAKLAINCommandHandler(IGenericRepositoryAsync<RFSCOHUTANGPIHAKLAIN> RFSCOHUTANGPIHAKLAIN, IMapper mapper)
        {
            _RFSCOHUTANGPIHAKLAIN = RFSCOHUTANGPIHAKLAIN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>> Handle(RFSCOHUTANGPIHAKLAINPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSCOHUTANGPIHAKLAIN = _mapper.Map<RFSCOHUTANGPIHAKLAIN>(request);

                var returnedRFSCOHUTANGPIHAKLAIN = await _RFSCOHUTANGPIHAKLAIN.AddAsync(RFSCOHUTANGPIHAKLAIN, callSave: false);

                // var response = _mapper.Map<RFSCOHUTANGPIHAKLAINResponseDto>(returnedRFSCOHUTANGPIHAKLAIN);
                var response = _mapper.Map<RFSCOHUTANGPIHAKLAINResponseDto>(returnedRFSCOHUTANGPIHAKLAIN);

                await _RFSCOHUTANGPIHAKLAIN.SaveChangeAsync();
                return ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}