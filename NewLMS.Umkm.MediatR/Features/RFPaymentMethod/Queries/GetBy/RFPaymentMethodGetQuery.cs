using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFPaymentMethods;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFPaymentMethods.Queries
{
    public class RFPaymentMethodGetQuery : RFPaymentMethodFindRequestDto, IRequest<ServiceResponse<RFPaymentMethodResponseDto>>
    {
    }

    public class RFPaymentMethodGetQueryHandler : IRequestHandler<RFPaymentMethodGetQuery, ServiceResponse<RFPaymentMethodResponseDto>>
    {
        private IGenericRepositoryAsync<RFPaymentMethod> _RFPaymentMethod;
        private readonly IMapper _mapper;

        public RFPaymentMethodGetQueryHandler(IGenericRepositoryAsync<RFPaymentMethod> RFPaymentMethod, IMapper mapper)
        {
            _RFPaymentMethod = RFPaymentMethod;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFPaymentMethodResponseDto>> Handle(RFPaymentMethodGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFPaymentMethod.GetByIdAsync(request.PAY_CODE, "PAY_CODE");
                if (data == null)
                    return ServiceResponse<RFPaymentMethodResponseDto>.Return404("Data RFPaymentMethod not found");
                var response = _mapper.Map<RFPaymentMethodResponseDto>(data);
                return ServiceResponse<RFPaymentMethodResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFPaymentMethodResponseDto>.ReturnException(ex);
            }
        }
    }
}