using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfMappings;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfMappings.Queries
{
    public class RfMappingsSubProductQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfMappingSubProductResponse>>>
    {
    }

    public class RfMappingsSubProductQueryHandler : IRequestHandler<RfMappingsSubProductQuery, PagedResponse<IEnumerable<RfMappingSubProductResponse>>>
    {
        private IGenericRepositoryAsync<RfMappingSubProduct> _rfMappingSubProduct;
        private readonly IMapper _mapper;

        public RfMappingsSubProductQueryHandler(IGenericRepositoryAsync<RfMappingSubProduct> rfMappingSubProduct, IMapper mapper)
        {
            _rfMappingSubProduct = rfMappingSubProduct;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfMappingSubProductResponse>>> Handle(RfMappingsSubProductQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfProduct",
                "RfSubProduct",
                "CreditPurpose",
                "ApplicationType",
            };
            var data = await _rfMappingSubProduct.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfMappingSubProductResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfMappingSubProductResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
