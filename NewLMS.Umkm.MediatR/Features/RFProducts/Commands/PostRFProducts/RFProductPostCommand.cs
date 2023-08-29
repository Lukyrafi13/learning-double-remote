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
    public class RFProductPostCommand : RFProductPostRequestDto, IRequest<ServiceResponse<RFProductResponseDto>>
    {

    }
    public class PostRFProductCommandHandler : IRequestHandler<RFProductPostCommand, ServiceResponse<RFProductResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFProduct> _rfProduct;
        private readonly IMapper _mapper;

        public PostRFProductCommandHandler(IGenericRepositoryAsync<RFProduct> rfProduct, IMapper mapper)
        {
            _rfProduct = rfProduct;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFProductResponseDto>> Handle(RFProductPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var rfProduct = new RFProduct();

                rfProduct.Active = true;
                rfProduct.ProductId = request.ProductId;
                rfProduct.ProductDesc = request.ProductDesc;
                rfProduct.ProductType = request.ProductType;
                rfProduct.DefTenor = request.DefTenor;
                rfProduct.MaxTenor = request.MaxTenor;
                rfProduct.DefIntType = request.DefIntType;
                rfProduct.DefInterest = request.DefInterest;
                rfProduct.MinInterest = request.MinInterest;
                rfProduct.MaxInterest = request.MaxInterest;
                rfProduct.DefProvPCTFee = request.DefProvPCTFee;
                rfProduct.DefAdminFee = request.DefAdminFee;
                rfProduct.CoreCode = request.CoreCode;
                rfProduct.MaxLimit = request.MaxLimit;
                rfProduct.LimitAppR = request.LimitAppR;
                rfProduct.MinLimit = request.MinLimit;

                var returnedRfProduct = await _rfProduct.AddAsync(rfProduct, callSave: false);

                // var response = _mapper.Map<RFProductResponseDto>(returnedRfProduct);
                var response = new RFProductResponseDto();
                
                response.Id = returnedRfProduct.Id;
                response.Active = returnedRfProduct.Active;
                response.ProductId = returnedRfProduct.ProductId;
                response.ProductDesc = returnedRfProduct.ProductDesc;
                response.ProductType = returnedRfProduct.ProductType;
                response.DefTenor = returnedRfProduct.DefTenor;
                response.MaxTenor = returnedRfProduct.MaxTenor;
                response.DefIntType = returnedRfProduct.DefIntType;
                response.DefInterest = returnedRfProduct.DefInterest;
                response.MinInterest = returnedRfProduct.MinInterest;
                response.MaxInterest = returnedRfProduct.MaxInterest;
                response.DefProvPCTFee = returnedRfProduct.DefProvPCTFee;
                response.DefAdminFee = returnedRfProduct.DefAdminFee;
                response.CoreCode = returnedRfProduct.CoreCode;
                response.MaxLimit = returnedRfProduct.MaxLimit;
                response.LimitAppR = returnedRfProduct.LimitAppR;
                response.MinLimit = returnedRfProduct.MinLimit;

                await _rfProduct.SaveChangeAsync();
                return ServiceResponse<RFProductResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFProductResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}