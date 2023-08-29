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
    public class RFSubProductPutCommand : RFSubProductPutRequestDto, IRequest<ServiceResponse<RFSubProductResponseDto>>
    {
    }

    public class PutRFSubProductCommandHandler : IRequestHandler<RFSubProductPutCommand, ServiceResponse<RFSubProductResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSubProduct> _RFSubProduct;
        private readonly IMapper _mapper;

        public PutRFSubProductCommandHandler(IGenericRepositoryAsync<RFSubProduct> RFSubProduct, IMapper mapper){
            _RFSubProduct = RFSubProduct;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSubProductResponseDto>> Handle(RFSubProductPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSubProduct = await _RFSubProduct.GetByIdAsync(request.SubProductId, "SubProductId");
                existingRFSubProduct.SubProductId = request.SubProductId;
                existingRFSubProduct.SubProductDesc = request.SubProductDesc;
                existingRFSubProduct.ProductId = request.ProductId;
                existingRFSubProduct.CoreCode = request.CoreCode;
                existingRFSubProduct.Active = request.Active;
                existingRFSubProduct.MandNPWP = request.MandNPWP;
                existingRFSubProduct.LPCode = request.LPCode;
                existingRFSubProduct.SIKPSkema = request.SIKPSkema;
                existingRFSubProduct.SIKPParentSkema = request.SIKPParentSkema;
                
                await _RFSubProduct.UpdateAsync(existingRFSubProduct);

                var response = _mapper.Map<RFSubProductResponseDto>(existingRFSubProduct);

                return ServiceResponse<RFSubProductResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSubProductResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}