using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfBusinessFieldKUR;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfBusinessFieldKURs.Queries.GetFilterRfBusinessFieldKURs
{
    public class RfBusinessFieldKURsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfBusinessFieldKURResponse>>>
    {
    }

    public class RfBusinessFieldKURsGetFilterQueryHandler : IRequestHandler<RfBusinessFieldKURsGetFilterQuery, PagedResponse<IEnumerable<RfBusinessFieldKURResponse>>>
    {
        private IGenericRepositoryAsync<RfBusinessFieldKUR> _rfBusinessFieldKUR;
        private readonly IMapper _mapper;

        public RfBusinessFieldKURsGetFilterQueryHandler(IGenericRepositoryAsync<RfBusinessFieldKUR> rfBusinessFieldKUR, IMapper mapper)
        {
            _rfBusinessFieldKUR = rfBusinessFieldKUR;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfBusinessFieldKURResponse>>> Handle(RfBusinessFieldKURsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfBusinessFieldKUR.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfBusinessFieldKURResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfBusinessFieldKURResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
