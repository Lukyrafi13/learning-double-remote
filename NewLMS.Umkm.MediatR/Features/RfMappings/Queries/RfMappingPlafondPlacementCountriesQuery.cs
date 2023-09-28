using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfMappingPlafondPlacementCountries;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfMappings.Queries
{
    public class RfMappingPlafondPlacementCountriesQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfMappingPlafondPlacementCountriesResponse>>>
    {
    }

    public class RfMappingPlafondPlacementCountriesQueryHandler : IRequestHandler<RfMappingPlafondPlacementCountriesQuery, PagedResponse<IEnumerable<RfMappingPlafondPlacementCountriesResponse>>>
    {
        private IGenericRepositoryAsync<RfMappingPlafondPlacementCountry> _core;
        private readonly IMapper _mapper;

        public RfMappingPlafondPlacementCountriesQueryHandler(IGenericRepositoryAsync<RfMappingPlafondPlacementCountry> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfMappingPlafondPlacementCountriesResponse>>> Handle(RfMappingPlafondPlacementCountriesQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfPlacementCountry",
                "ApplicationType",
            };
            var data = await _core.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfMappingPlafondPlacementCountriesResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfMappingPlafondPlacementCountriesResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
