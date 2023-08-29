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
    public class RfProductPutCommand : RfProductPutRequestDto, IRequest<ServiceResponse<RfProductResponseDto>>
    {
    }

    public class PutRfProductCommandHandler : IRequestHandler<RfProductPutCommand, ServiceResponse<RfProductResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfProduct> _rfProduct;
        private readonly IMapper _mapper;

        public PutRfProductCommandHandler(IGenericRepositoryAsync<RfProduct> rfProduct, IMapper mapper){
            _rfProduct = rfProduct;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfProductResponseDto>> Handle(RfProductPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRfProduct = await _rfProduct.GetByIdAsync(request.ProductId, "ProductId");
                existingRfProduct.ProductDesc = request.ProductDesc;
                existingRfProduct.ProductType = request.ProductType;
                existingRfProduct.DefTenor = request.DefTenor;
                existingRfProduct.MaxTenor = request.MaxTenor;
                existingRfProduct.DefIntType = request.DefIntType;
                existingRfProduct.DefInterest = request.DefInterest;
                existingRfProduct.MinInterest = request.MinInterest;
                existingRfProduct.MaxInterest = request.MaxInterest;
                existingRfProduct.DefProvPCTFee = request.DefProvPCTFee;
                existingRfProduct.DefAdminFee = request.DefAdminFee;
                existingRfProduct.CoreCode = request.CoreCode;
                existingRfProduct.Active = request.Active;
                existingRfProduct.MaxLimit = request.MaxLimit;
                existingRfProduct.LimitAppR = request.LimitAppR;
                existingRfProduct.MinLimit = request.MinLimit;
                
                await _rfProduct.UpdateAsync(existingRfProduct);

                var response = new RfProductResponseDto();
                response.Id = existingRfProduct.Id;
                response.ProductId = existingRfProduct.ProductId;
                response.ProductDesc = existingRfProduct.ProductDesc;
                response.ProductType = existingRfProduct.ProductType;
                response.DefTenor = existingRfProduct.DefTenor;
                response.MaxTenor = existingRfProduct.MaxTenor;
                response.DefIntType = existingRfProduct.DefIntType;
                response.DefInterest = existingRfProduct.DefInterest;
                response.MinInterest = existingRfProduct.MinInterest;
                response.MaxInterest = existingRfProduct.MaxInterest;
                response.DefProvPCTFee = existingRfProduct.DefProvPCTFee;
                response.DefAdminFee = existingRfProduct.DefAdminFee;
                response.CoreCode = existingRfProduct.CoreCode;
                response.Active = existingRfProduct.Active;
                response.MaxLimit = existingRfProduct.MaxLimit;
                response.LimitAppR = existingRfProduct.LimitAppR;
                response.MinLimit = existingRfProduct.MinLimit;

                return ServiceResponse<RfProductResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfProductResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}