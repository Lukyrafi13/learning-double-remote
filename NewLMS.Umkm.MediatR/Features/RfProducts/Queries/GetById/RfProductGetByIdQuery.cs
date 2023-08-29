using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfProducts;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfProducts.Queries
{
    public class RfProductsGetByIdQuery : RfProductFindRequestDto, IRequest<ServiceResponse<RfProductResponseDto>>
    {
    }

    public class GetByIdRfProductQueryHandler : IRequestHandler<RfProductsGetByIdQuery, ServiceResponse<RfProductResponseDto>>
    {
        private IGenericRepositoryAsync<RfProduct> _rfProduct;
        private readonly IMapper _mapper;

        public GetByIdRfProductQueryHandler(IGenericRepositoryAsync<RfProduct> rfProduct, IMapper mapper)
        {
            _rfProduct = rfProduct;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RfProductResponseDto>> Handle(RfProductsGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _rfProduct.GetByIdAsync(request.ProductId, "ProductId");
                if (data == null)
                    return ServiceResponse<RfProductResponseDto>.Return404("Data RfProduct not found");
                var response = new RfProductResponseDto();
                
                response.Id = data.Id;
                response.Active = data.Active;
                response.ProductId = data.ProductId;
                response.ProductDesc = data.ProductDesc;
                response.ProductType = data.ProductType;
                response.DefTenor = data.DefTenor;
                response.MaxTenor = data.MaxTenor;
                response.DefIntType = data.DefIntType;
                response.DefInterest = data.DefInterest;
                response.MinInterest = data.MinInterest;
                response.MaxInterest = data.MaxInterest;
                response.DefProvPCTFee = data.DefProvPCTFee;
                response.DefAdminFee = data.DefAdminFee;
                response.CoreCode = data.CoreCode;
                response.MaxLimit = data.MaxLimit;
                response.LimitAppR = data.LimitAppR;
                response.MinLimit = data.MinLimit;
                return ServiceResponse<RfProductResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfProductResponseDto>.ReturnException(ex);
            }
        }
    }
}