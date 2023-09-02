using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfProduct;
using NewLMS.UMKM.Data.Dto.RfTargetStatus;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.MediatR.Features.RfProducts.Queries.GetFilterRfProducts;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfTargetStatuses.Queries.GetFilterRfTargetStatuses
{
    public class RfTargetStatusesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfTargetStatusResponse>>>
    {
    }

    public class RfTargetStatusesGetFilterQueryHandler : IRequestHandler<RfTargetStatusesGetFilterQuery, PagedResponse<IEnumerable<RfTargetStatusResponse>>>
    {
        private IGenericRepositoryAsync<RfTargetStatus> _rfTargetStatus;
        private readonly IMapper _mapper;

        public RfTargetStatusesGetFilterQueryHandler(IGenericRepositoryAsync<RfTargetStatus> rfTargetStatus, IMapper mapper)
        {
            _rfTargetStatus = rfTargetStatus;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfTargetStatusResponse>>> Handle(RfTargetStatusesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfTargetStatus.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfTargetStatusResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfTargetStatusResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
