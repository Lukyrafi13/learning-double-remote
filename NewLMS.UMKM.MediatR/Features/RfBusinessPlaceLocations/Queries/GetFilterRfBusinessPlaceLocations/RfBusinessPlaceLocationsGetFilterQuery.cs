using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfBusinessPlaceLocations.Queries.GetFilterRfBusinessPlaceLocations
{
    public class RfBusinessPlaceLocationsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfBusinessPlaceLocationResponse>>>
    {
    }

    public class RfBusinessPlaceLocationsGetFilterQueryHandler : IRequestHandler<RfBusinessPlaceLocationsGetFilterQuery, PagedResponse<IEnumerable<RfBusinessPlaceLocationResponse>>>
    {
        private IGenericRepositoryAsync<RfBusinessPlaceLocation> _rfBusinessPlaceLocation;
        private readonly IMapper _mapper;

        public RfBusinessPlaceLocationsGetFilterQueryHandler(IGenericRepositoryAsync<RfBusinessPlaceLocation> rfBusinessPlaceLocation, IMapper mapper)
        {
            _rfBusinessPlaceLocation = rfBusinessPlaceLocation;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfBusinessPlaceLocationResponse>>> Handle(RfBusinessPlaceLocationsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfBusinessPlaceLocation.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfBusinessPlaceLocationResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfBusinessPlaceLocationResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
