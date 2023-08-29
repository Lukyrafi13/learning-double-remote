using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFPaymentMethods;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFPaymentMethods.Commands
{
    public class RFPaymentMethodDeleteCommand : RFPaymentMethodFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFPaymentMethodCommandHandler : IRequestHandler<RFPaymentMethodDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFPaymentMethod> _RFPaymentMethod;
        private readonly IMapper _mapper;

        public DeleteRFPaymentMethodCommandHandler(IGenericRepositoryAsync<RFPaymentMethod> RFPaymentMethod, IMapper mapper){
            _RFPaymentMethod = RFPaymentMethod;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFPaymentMethodDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFPaymentMethod.GetByIdAsync(request.PAY_CODE, "PAY_CODE");
            rFProduct.IsDeleted = true;
            await _RFPaymentMethod.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}