using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfBusinessPlaceType;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfBusinessTypePlaces.Queries.GetFilterRfBusinessTypePlaces
{
    public class RfBusinessPlaceTypeGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfBusinessPlaceTypeResponse>>>
    {
    }

    public class RfBusinessPlaceTypeGetFilterQueryHandler : IRequestHandler<RfBusinessPlaceTypeGetFilterQuery, PagedResponse<IEnumerable<RfBusinessPlaceTypeResponse>>>
    {
        private IGenericRepositoryAsync<RfBusinessPlaceType> _rfBusinessPlaceType;
        private readonly IMapper _mapper;

        public RfBusinessPlaceTypeGetFilterQueryHandler(IGenericRepositoryAsync<RfBusinessPlaceType> rfBusinessPlaceType, IMapper mapper)
        {
            _rfBusinessPlaceType = rfBusinessPlaceType;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfBusinessPlaceTypeResponse>>> Handle(RfBusinessPlaceTypeGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfBusinessPlaceType.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfBusinessPlaceTypeResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfBusinessPlaceTypeResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
