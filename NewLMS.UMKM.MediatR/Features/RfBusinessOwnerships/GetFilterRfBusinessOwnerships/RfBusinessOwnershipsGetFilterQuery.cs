using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfBusinessOwnership;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfBusinessOwnerships.GetFilterRfBusinessOwnerships
{
    public class RfBusinessOwnershipsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfBusinessOwnershipResponse>>>
    {
    }

    public class RfBusinessOwnershipsGetFilterQueryHandler : IRequestHandler<RfBusinessOwnershipsGetFilterQuery, PagedResponse<IEnumerable<RfBusinessOwnershipResponse>>>
    {
        private IGenericRepositoryAsync<RfBusinessOwnership> _rfBusinessOwnership;
        private readonly IMapper _mapper;

        public RfBusinessOwnershipsGetFilterQueryHandler(IGenericRepositoryAsync<RfBusinessOwnership> rfBusinessOwnership, IMapper mapper)
        {
            _rfBusinessOwnership = rfBusinessOwnership;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfBusinessOwnershipResponse>>> Handle(RfBusinessOwnershipsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfBusinessOwnership.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfBusinessOwnershipResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfBusinessOwnershipResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
