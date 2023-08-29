using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfProducts;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfProducts.Queries
{
    public class RfProductsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfProductResponseDto>>>
    {
    }

    public class GetFilterRfProductQueryHandler : IRequestHandler<RfProductsGetFilterQuery, PagedResponse<IEnumerable<RfProductResponseDto>>>
    {
        private IGenericRepositoryAsync<RfProduct> _rfProduct;
        private readonly IMapper _mapper;

        public GetFilterRfProductQueryHandler(IGenericRepositoryAsync<RfProduct> rfProduct, IMapper mapper)
        {
            _rfProduct = rfProduct;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfProductResponseDto>>> Handle(RfProductsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfProduct.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfProductResponseDto>>(data.Results);
            IEnumerable<RfProductResponseDto> dataVm;
            var listResponse = new List<RfProductResponseDto>();

            foreach (var res in data.Results){
                var response = new RfProductResponseDto();
                
                response.Id = res.Id;
                response.Active = res.Active;
                response.ProductId = res.ProductId;
                response.ProductDesc = res.ProductDesc;
                response.ProductType = res.ProductType;
                response.DefTenor = res.DefTenor;
                response.MaxTenor = res.MaxTenor;
                response.DefIntType = res.DefIntType;
                response.DefInterest = res.DefInterest;
                response.MinInterest = res.MinInterest;
                response.MaxInterest = res.MaxInterest;
                response.DefProvPCTFee = res.DefProvPCTFee;
                response.DefAdminFee = res.DefAdminFee;
                response.CoreCode = res.CoreCode;
                response.MaxLimit = res.MaxLimit;
                response.LimitAppR = res.LimitAppR;
                response.MinLimit = res.MinLimit;

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfProductResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}