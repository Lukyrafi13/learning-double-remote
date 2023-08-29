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
    public class RFProductPutCommand : RFProductPutRequestDto, IRequest<ServiceResponse<RFProductResponseDto>>
    {
    }

    public class PutRFProductCommandHandler : IRequestHandler<RFProductPutCommand, ServiceResponse<RFProductResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFProduct> _rfProduct;
        private readonly IMapper _mapper;

        public PutRFProductCommandHandler(IGenericRepositoryAsync<RFProduct> rfProduct, IMapper mapper){
            _rfProduct = rfProduct;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFProductResponseDto>> Handle(RFProductPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFProduct = await _rfProduct.GetByIdAsync(request.ProductId, "ProductId");
                existingRFProduct.ProductDesc = request.ProductDesc;
                existingRFProduct.ProductType = request.ProductType;
                existingRFProduct.DefTenor = request.DefTenor;
                existingRFProduct.MaxTenor = request.MaxTenor;
                existingRFProduct.DefIntType = request.DefIntType;
                existingRFProduct.DefInterest = request.DefInterest;
                existingRFProduct.MinInterest = request.MinInterest;
                existingRFProduct.MaxInterest = request.MaxInterest;
                existingRFProduct.DefProvPCTFee = request.DefProvPCTFee;
                existingRFProduct.DefAdminFee = request.DefAdminFee;
                existingRFProduct.CoreCode = request.CoreCode;
                existingRFProduct.Active = request.Active;
                existingRFProduct.MaxLimit = request.MaxLimit;
                existingRFProduct.LimitAppR = request.LimitAppR;
                existingRFProduct.MinLimit = request.MinLimit;
                
                await _rfProduct.UpdateAsync(existingRFProduct);

                var response = new RFProductResponseDto();
                response.Id = existingRFProduct.Id;
                response.ProductId = existingRFProduct.ProductId;
                response.ProductDesc = existingRFProduct.ProductDesc;
                response.ProductType = existingRFProduct.ProductType;
                response.DefTenor = existingRFProduct.DefTenor;
                response.MaxTenor = existingRFProduct.MaxTenor;
                response.DefIntType = existingRFProduct.DefIntType;
                response.DefInterest = existingRFProduct.DefInterest;
                response.MinInterest = existingRFProduct.MinInterest;
                response.MaxInterest = existingRFProduct.MaxInterest;
                response.DefProvPCTFee = existingRFProduct.DefProvPCTFee;
                response.DefAdminFee = existingRFProduct.DefAdminFee;
                response.CoreCode = existingRFProduct.CoreCode;
                response.Active = existingRFProduct.Active;
                response.MaxLimit = existingRFProduct.MaxLimit;
                response.LimitAppR = existingRFProduct.LimitAppR;
                response.MinLimit = existingRFProduct.MinLimit;

                return ServiceResponse<RFProductResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFProductResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}