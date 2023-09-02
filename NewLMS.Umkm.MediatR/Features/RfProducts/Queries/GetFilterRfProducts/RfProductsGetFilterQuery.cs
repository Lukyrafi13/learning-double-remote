using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfProduct;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.MediatR.Features.RfProducts.Queries.GetFilterRfProducts
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
