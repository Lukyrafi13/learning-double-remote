using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSubProducts;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSubProducts.Commands
{
    public class RFSubProductDeleteCommand : RFSubProductFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFSubProductCommandHandler : IRequestHandler<RFSubProductDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSubProduct> _RFSubProduct;
        private readonly IMapper _mapper;

        public DeleteRFSubProductCommandHandler(IGenericRepositoryAsync<RFSubProduct> RFSubProduct, IMapper mapper){
            _RFSubProduct = RFSubProduct;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSubProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSubProduct.GetByIdAsync(request.SubProductId, "SubProductId");
            rFProduct.IsDeleted = true;
            await _RFSubProduct.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}