using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfPlacementCountry;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfPlacementCountries.Queries.GetFilterRfPlacementCountries
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
