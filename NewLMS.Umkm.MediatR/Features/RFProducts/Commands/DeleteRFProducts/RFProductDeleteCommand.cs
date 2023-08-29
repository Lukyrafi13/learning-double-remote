using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFProducts;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFProducts.Commands
{
    public class RFProductDeleteCommand : RFProductFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFProductCommandHandler : IRequestHandler<RFProductDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFProduct> _rfProduct;
        private readonly IMapper _mapper;

        public DeleteRFProductCommandHandler(IGenericRepositoryAsync<RFProduct> rfProduct, IMapper mapper){
            _rfProduct = rfProduct;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _rfProduct.GetByIdAsync(request.ProductId, "ProductId");
            rFProduct.IsDeleted = true;
            await _rfProduct.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}