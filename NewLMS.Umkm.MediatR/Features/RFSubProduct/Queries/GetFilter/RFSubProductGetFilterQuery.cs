using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSubProducts;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSubProducts.Queries
{
    public class RFSubProductsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSubProductResponseDto>>>
    {
    }

    public class GetFilterRFSubProductQueryHandler : IRequestHandler<RFSubProductsGetFilterQuery, PagedResponse<IEnumerable<RFSubProductResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSubProduct> _RFSubProduct;
        private readonly IMapper _mapper;

        public GetFilterRFSubProductQueryHandler(IGenericRepositoryAsync<RFSubProduct> RFSubProduct, IMapper mapper)
        {
            _RFSubProduct = RFSubProduct;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSubProductResponseDto>>> Handle(RFSubProductsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSubProduct.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSubProductResponseDto>>(data.Results);
            IEnumerable<RFSubProductResponseDto> dataVm;
            var listResponse = new List<RFSubProductResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSubProductResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSubProductResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}