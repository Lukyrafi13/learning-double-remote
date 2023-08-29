using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFDebiturMemilikiUsahaLains;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFDebiturMemilikiUsahaLains.Commands
{
    public class RFDebiturMemilikiUsahaLainPostCommand : RFDebiturMemilikiUsahaLainPostRequestDto, IRequest<ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>>
    {

    }
    public class PostRFDebiturMemilikiUsahaLainCommandHandler : IRequestHandler<RFDebiturMemilikiUsahaLainPostCommand, ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>>
    {
        private readonly IGenericRepositoryAsync<DebiturMemilikiUsahaLain> _RFDebiturMemilikiUsahaLain;
        private readonly IMapper _mapper;

        public PostRFDebiturMemilikiUsahaLainCommandHandler(IGenericRepositoryAsync<DebiturMemilikiUsahaLain> RFDebiturMemilikiUsahaLain, IMapper mapper)
        {
            _RFDebiturMemilikiUsahaLain = RFDebiturMemilikiUsahaLain;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>> Handle(RFDebiturMemilikiUsahaLainPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFDebiturMemilikiUsahaLain = _mapper.Map<DebiturMemilikiUsahaLain>(request);

                var returnedRFDebiturMemilikiUsahaLain = await _RFDebiturMemilikiUsahaLain.AddAsync(RFDebiturMemilikiUsahaLain, callSave: false);

                // var response = _mapper.Map<RFDebiturMemilikiUsahaLainResponseDto>(returnedRFDebiturMemilikiUsahaLain);
                var response = _mapper.Map<RFDebiturMemilikiUsahaLainResponseDto>(returnedRFDebiturMemilikiUsahaLain);

                await _RFDebiturMemilikiUsahaLain.SaveChangeAsync();
                return ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}