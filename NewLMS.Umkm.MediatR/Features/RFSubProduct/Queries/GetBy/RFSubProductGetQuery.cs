using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSubProducts;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSubProducts.Queries
{
    public class RFSubProductGetQuery : RFSubProductFindRequestDto, IRequest<ServiceResponse<RFSubProductResponseDto>>
    {
    }

    public class RFSubProductGetQueryHandler : IRequestHandler<RFSubProductGetQuery, ServiceResponse<RFSubProductResponseDto>>
    {
        private IGenericRepositoryAsync<RFSubProduct> _RFSubProduct;
        private readonly IMapper _mapper;

        public RFSubProductGetQueryHandler(IGenericRepositoryAsync<RFSubProduct> RFSubProduct, IMapper mapper)
        {
            _RFSubProduct = RFSubProduct;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSubProductResponseDto>> Handle(RFSubProductGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSubProduct.GetByIdAsync(request.SubProductId, "SubProductId");
                if (data == null)
                    return ServiceResponse<RFSubProductResponseDto>.Return404("Data RFSubProduct not found");
                var response = _mapper.Map<RFSubProductResponseDto>(data);
                return ServiceResponse<RFSubProductResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSubProductResponseDto>.ReturnException(ex);
            }
        }
    }
}