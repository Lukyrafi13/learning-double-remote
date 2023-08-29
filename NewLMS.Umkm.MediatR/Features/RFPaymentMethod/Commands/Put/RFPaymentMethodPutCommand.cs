using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFPaymentMethods;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFPaymentMethods.Commands
{
    public class RFPaymentMethodPutCommand : RFPaymentMethodPutRequestDto, IRequest<ServiceResponse<RFPaymentMethodResponseDto>>
    {
    }

    public class RFPaymentMethodPutCommandHandler : IRequestHandler<RFPaymentMethodPutCommand, ServiceResponse<RFPaymentMethodResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFPaymentMethod> _RFPaymentMethod;
        private readonly IMapper _mapper;

        public RFPaymentMethodPutCommandHandler(IGenericRepositoryAsync<RFPaymentMethod> RFPaymentMethod, IMapper mapper)
        {
            _RFPaymentMethod = RFPaymentMethod;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFPaymentMethodResponseDto>> Handle(RFPaymentMethodPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFPaymentMethod = await _RFPaymentMethod.GetByIdAsync(request.PAY_CODE, "PAY_CODE");
                
                existingRFPaymentMethod.PAY_DESC = request.PAY_DESC;
                existingRFPaymentMethod.CORE_CODE = request.CORE_CODE;
                existingRFPaymentMethod.Active = request.Active;
                await _RFPaymentMethod.UpdateAsync(existingRFPaymentMethod);

                var response = _mapper.Map<RFPaymentMethodResponseDto>(existingRFPaymentMethod);

                return ServiceResponse<RFPaymentMethodResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFPaymentMethodResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}