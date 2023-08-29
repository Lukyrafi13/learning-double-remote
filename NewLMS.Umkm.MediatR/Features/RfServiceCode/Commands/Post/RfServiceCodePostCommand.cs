using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfServiceCodes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfServiceCodes.Commands
{
    public class RfServiceCodePostCommand : RfServiceCodePostRequestDto, IRequest<ServiceResponse<RfServiceCodeResponseDto>>
    {

    }
    public class PostRfServiceCodeCommandHandler : IRequestHandler<RfServiceCodePostCommand, ServiceResponse<RfServiceCodeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfServiceCode> _RfServiceCode;
        private readonly IMapper _mapper;

        public PostRfServiceCodeCommandHandler(IGenericRepositoryAsync<RfServiceCode> RfServiceCode, IMapper mapper)
        {
            _RfServiceCode = RfServiceCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfServiceCodeResponseDto>> Handle(RfServiceCodePostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RfServiceCode = _mapper.Map<RfServiceCode>(request);

                var returnedRfServiceCode = await _RfServiceCode.AddAsync(RfServiceCode, callSave: false);

                // var response = _mapper.Map<RfServiceCodeResponseDto>(returnedRfStatusTarget);
                var response = _mapper.Map<RfServiceCodeResponseDto>(returnedRfServiceCode);

                await _RfServiceCode.SaveChangeAsync();
                return ServiceResponse<RfServiceCodeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfServiceCodeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}