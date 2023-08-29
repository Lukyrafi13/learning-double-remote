using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFLamaUsahaLains;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFLamaUsahaLains.Commands
{
    public class RFLamaUsahaLainPostCommand : RFLamaUsahaLainPostRequestDto, IRequest<ServiceResponse<RFLamaUsahaLainResponseDto>>
    {

    }
    public class RFLamaUsahaLainPostCommandHandler : IRequestHandler<RFLamaUsahaLainPostCommand, ServiceResponse<RFLamaUsahaLainResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFLamaUsahaLain> _RFLamaUsahaLain;
        private readonly IMapper _mapper;

        public RFLamaUsahaLainPostCommandHandler(IGenericRepositoryAsync<RFLamaUsahaLain> RFLamaUsahaLain, IMapper mapper)
        {
            _RFLamaUsahaLain = RFLamaUsahaLain;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFLamaUsahaLainResponseDto>> Handle(RFLamaUsahaLainPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFLamaUsahaLain = _mapper.Map<RFLamaUsahaLain>(request);

                var returnedRFLamaUsahaLain = await _RFLamaUsahaLain.AddAsync(RFLamaUsahaLain, callSave: false);

                // var response = _mapper.Map<RFLamaUsahaLainResponseDto>(returnedRFLamaUsahaLain);
                var response = _mapper.Map<RFLamaUsahaLainResponseDto>(returnedRFLamaUsahaLain);

                await _RFLamaUsahaLain.SaveChangeAsync();
                return ServiceResponse<RFLamaUsahaLainResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFLamaUsahaLainResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}