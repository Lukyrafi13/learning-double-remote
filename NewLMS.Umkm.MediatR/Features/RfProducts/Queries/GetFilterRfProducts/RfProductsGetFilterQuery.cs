using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Data.Dto.RfProducts;

namespace NewLMS.Umkm.MediatR.Features.RfProducts.Queries.GetFilterRfProducts
{
    public class RfProductsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfProductResponse>>>
    {
    }

    public class RfProductsGetFilterQueryHandler : IRequestHandler<RfProductsGetFilterQuery, PagedResponse<IEnumerable<RfProductResponse>>>
    {
        private IGenericRepositoryAsync<RfProduct> _rfProduct;
        private readonly IMapper _mapper;

        public RfProductsGetFilterQueryHandler(IGenericRepositoryAsync<RfProduct> rfProduct, IMapper mapper)
        {
            _rfProduct = rfProduct;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfProductResponse>>> Handle(RfProductsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfProduct.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfProductResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfProductResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
