using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfBusinessPlaceOwnership;
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

namespace NewLMS.UMKM.MediatR.Features.RfBusinessPlaceOwnerships.Queries.GetFilterRfBusinessPlaceOwnerships
{
    public class RfBusinessPlaceOwnershipsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfBusinessPlaceOwnershipResponse>>>
    {
    }

    public class RfBusinessPlaceOwnershipsGetFilterQueryHandler : IRequestHandler<RfBusinessPlaceOwnershipsGetFilterQuery, PagedResponse<IEnumerable<RfBusinessPlaceOwnershipResponse>>>
    {
        private IGenericRepositoryAsync<RfBusinessPlaceOwnership> _rfBusinessPlaceOwnership;
        private readonly IMapper _mapper;

        public RfBusinessPlaceOwnershipsGetFilterQueryHandler(IGenericRepositoryAsync<RfBusinessPlaceOwnership> rfBusinessPlaceOwnership, IMapper mapper)
        {
            _rfBusinessPlaceOwnership = rfBusinessPlaceOwnership;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfBusinessPlaceOwnershipResponse>>> Handle(RfBusinessPlaceOwnershipsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfBusinessPlaceLocation",
            };
            var data = await _rfBusinessPlaceOwnership.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfBusinessPlaceOwnershipResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfBusinessPlaceOwnershipResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
