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
    public class RfServiceCodePutCommand : RfServiceCodePutRequestDto, IRequest<ServiceResponse<RfServiceCodeResponseDto>>
    {
    }

    public class PutRfServiceCodeCommandHandler : IRequestHandler<RfServiceCodePutCommand, ServiceResponse<RfServiceCodeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfServiceCode> _RfServiceCode;
        private readonly IMapper _mapper;

        public PutRfServiceCodeCommandHandler(IGenericRepositoryAsync<RfServiceCode> RfServiceCode, IMapper mapper){
            _RfServiceCode = RfServiceCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfServiceCodeResponseDto>> Handle(RfServiceCodePutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRfServiceCode = await _RfServiceCode.GetByIdAsync(request.ServiceCode, "ServiceCode");
                
                existingRfServiceCode = _mapper.Map<RfServiceCodePutRequestDto, RfServiceCode>(request, existingRfServiceCode);
                
                await _RfServiceCode.UpdateAsync(existingRfServiceCode);

                var response = _mapper.Map<RfServiceCodeResponseDto>(existingRfServiceCode);

                return ServiceResponse<RfServiceCodeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfServiceCodeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}