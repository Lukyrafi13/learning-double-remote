using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto;
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

namespace NewLMS.UMKM.MediatR.Features.RfBusinessPlaceLocations.Queries.GetFilterRfBusinessPlaceLocations
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
