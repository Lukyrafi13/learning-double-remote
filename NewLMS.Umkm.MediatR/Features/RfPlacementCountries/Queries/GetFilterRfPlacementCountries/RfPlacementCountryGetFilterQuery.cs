using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfPlacementCountry;
using NewLMS.UMKM.Data.Dto.RfSubProduct;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.MediatR.Features.RfSubProducts.Queries.GetFilterRfSubProducts;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfPlacementCountries.Queries.GetFilterRfPlacementCountries
{
    public class RfPlacementCountryGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfPlacementCountryResponse>>>
    {
    }

    public class RfPlacementCountryGetFilterQueryHandler : IRequestHandler<RfPlacementCountryGetFilterQuery, PagedResponse<IEnumerable<RfPlacementCountryResponse>>>
    {
        private IGenericRepositoryAsync<RfPlacementCountry> _rfPlacementCountry;
        private readonly IMapper _mapper;

        public RfPlacementCountryGetFilterQueryHandler(IGenericRepositoryAsync<RfPlacementCountry> rfPlacementCountry, IMapper mapper)
        {
            _rfPlacementCountry = rfPlacementCountry;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfPlacementCountryResponse>>> Handle(RfPlacementCountryGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfPlacementCountry.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfPlacementCountryResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfPlacementCountryResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
