using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfProducts;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfProducts.Commands
{
    public class RfProductDeleteCommand : RfProductFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRfProductCommandHandler : IRequestHandler<RfProductDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfProduct> _rfProduct;
        private readonly IMapper _mapper;

        public DeleteRfProductCommandHandler(IGenericRepositoryAsync<RfProduct> rfProduct, IMapper mapper){
            _rfProduct = rfProduct;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _rfProduct.GetByIdAsync(request.ProductId, "ProductId");
            rFProduct.IsDeleted = true;
            await _rfProduct.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}