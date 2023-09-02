using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfBusinessLocation;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfBusinessLocations.Queries.GetFilterRfBusinessLocations
{
    public class RfBusinessLocationsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfBusinessLocationResponse>>>
    {
    }

    public class RfBusinessLocationsGetFilterQueryHandler : IRequestHandler<RfBusinessLocationsGetFilterQuery, PagedResponse<IEnumerable<RfBusinessLocationResponse>>>
    {
        private IGenericRepositoryAsync<RfBusinessLocation> rfBusinessLocation;
        private readonly IMapper _mapper;

        public RfBusinessLocationsGetFilterQueryHandler(IGenericRepositoryAsync<RfBusinessLocation> rfBusinessLocation, IMapper mapper)
        {
            this.rfBusinessLocation = rfBusinessLocation;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfBusinessLocationResponse>>> Handle(RfBusinessLocationsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await rfBusinessLocation.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfBusinessLocationResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfBusinessLocationResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
