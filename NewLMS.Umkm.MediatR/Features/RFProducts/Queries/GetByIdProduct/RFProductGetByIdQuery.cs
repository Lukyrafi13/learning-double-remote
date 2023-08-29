using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFProducts;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFProducts.Queries
{
    public class RFProductsGetByIdQuery : RFProductFindRequestDto, IRequest<ServiceResponse<RFProductResponseDto>>
    {
    }

    public class GetByIdRFProductQueryHandler : IRequestHandler<RFProductsGetByIdQuery, ServiceResponse<RFProductResponseDto>>
    {
        private IGenericRepositoryAsync<RFProduct> _rfProduct;
        private readonly IMapper _mapper;

        public GetByIdRFProductQueryHandler(IGenericRepositoryAsync<RFProduct> rfProduct, IMapper mapper)
        {
            _rfProduct = rfProduct;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFProductResponseDto>> Handle(RFProductsGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _rfProduct.GetByIdAsync(request.ProductId, "ProductId");
                if (data == null)
                    return ServiceResponse<RFProductResponseDto>.Return404("Data RFProduct not found");
                var response = new RFProductResponseDto();
                
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
                return ServiceResponse<RFProductResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFProductResponseDto>.ReturnException(ex);
            }
        }
    }
}