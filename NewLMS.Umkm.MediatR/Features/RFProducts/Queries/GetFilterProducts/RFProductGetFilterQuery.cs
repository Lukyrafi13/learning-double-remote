using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFProducts;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFProducts.Queries
{
    public class RFProductsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFProductResponseDto>>>
    {
    }

    public class GetFilterRFProductQueryHandler : IRequestHandler<RFProductsGetFilterQuery, PagedResponse<IEnumerable<RFProductResponseDto>>>
    {
        private IGenericRepositoryAsync<RFProduct> _rfProduct;
        private readonly IMapper _mapper;

        public GetFilterRFProductQueryHandler(IGenericRepositoryAsync<RFProduct> rfProduct, IMapper mapper)
        {
            _rfProduct = rfProduct;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFProductResponseDto>>> Handle(RFProductsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfProduct.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFProductResponseDto>>(data.Results);
            IEnumerable<RFProductResponseDto> dataVm;
            var listResponse = new List<RFProductResponseDto>();

            foreach (var res in data.Results){
                var response = new RFProductResponseDto();
                
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
            return new PagedResponse<IEnumerable<RFProductResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}