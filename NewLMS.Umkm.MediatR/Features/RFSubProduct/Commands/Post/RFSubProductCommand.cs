using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSubProducts;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSubProducts.Commands
{
    public class RFSubProductPostCommand : RFSubProductPostRequestDto, IRequest<ServiceResponse<RFSubProductResponseDto>>
    {

    }
    public class PostRFSubProductCommandHandler : IRequestHandler<RFSubProductPostCommand, ServiceResponse<RFSubProductResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSubProduct> _RFSubProduct;
        private readonly IMapper _mapper;

        public PostRFSubProductCommandHandler(IGenericRepositoryAsync<RFSubProduct> RFSubProduct, IMapper mapper)
        {
            _RFSubProduct = RFSubProduct;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSubProductResponseDto>> Handle(RFSubProductPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSubProduct = _mapper.Map<RFSubProduct>(request);

                var returnedRFSubProduct = await _RFSubProduct.AddAsync(RFSubProduct, callSave: false);

                // var response = _mapper.Map<RFSubProductResponseDto>(returnedRFSubProduct);
                var response = _mapper.Map<RFSubProductResponseDto>(returnedRFSubProduct);

                await _RFSubProduct.SaveChangeAsync();
                return ServiceResponse<RFSubProductResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSubProductResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}