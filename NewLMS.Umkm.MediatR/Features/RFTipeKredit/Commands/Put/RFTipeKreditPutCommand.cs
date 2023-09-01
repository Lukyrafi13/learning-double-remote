using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCreditTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCreditTypes.Commands
{
    public class RfCreditTypePutCommand : RfCreditTypePutRequestDto, IRequest<ServiceResponse<RfCreditTypeResponseDto>>
    {
    }

    public class PutRfCreditTypeCommandHandler : IRequestHandler<RfCreditTypePutCommand, ServiceResponse<RfCreditTypeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfCreditType> _RfCreditType;
        private readonly IMapper _mapper;

        public PutRfCreditTypeCommandHandler(IGenericRepositoryAsync<RfCreditType> RfCreditType, IMapper mapper)
        {
            _RfCreditType = RfCreditType;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfCreditTypeResponseDto>> Handle(RfCreditTypePutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRfCreditType = await _RfCreditType.GetByIdAsync(request.Code, "Code");
                
                existingRfCreditType = _mapper.Map<RfCreditTypePutRequestDto, RfCreditType>(request, existingRfCreditType);
                
                await _RfCreditType.UpdateAsync(existingRfCreditType);

                var response = _mapper.Map<RfCreditTypeResponseDto>(existingRfCreditType);

                return ServiceResponse<RfCreditTypeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCreditTypeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}