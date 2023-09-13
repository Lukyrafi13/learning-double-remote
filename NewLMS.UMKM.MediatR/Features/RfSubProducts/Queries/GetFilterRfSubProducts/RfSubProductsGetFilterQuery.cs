using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfSubProducts;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfSubProducts.Queries.GetFilterRfSubProducts
{
    public class RfSubProductsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfSubProductResponse>>>
    {
    }

    public class RfSubProductsGetFilterQueryHandler : IRequestHandler<RfSubProductsGetFilterQuery, PagedResponse<IEnumerable<RfSubProductResponse>>>
    {
        private IGenericRepositoryAsync<RfSubProduct> _rfSubProduct;
        private readonly IMapper _mapper;

        public RfSubProductsGetFilterQueryHandler(IGenericRepositoryAsync<RfSubProduct> rfSubProduct, IMapper mapper)
        {
            _rfSubProduct = rfSubProduct;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfSubProductResponse>>> Handle(RfSubProductsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfProduct",
                "RfLoanPurpose",
            };
            var data = await _rfSubProduct.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfSubProductResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfSubProductResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
