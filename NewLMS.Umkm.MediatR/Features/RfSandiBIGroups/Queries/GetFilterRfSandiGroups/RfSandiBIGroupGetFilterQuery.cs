using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfSandiBIGroup;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfSandiBIGroups.Queries.GetFilterRfSandiGroups
{
    public class RfSandiBIGroupGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfSandiBIGroupResponse>>>
    {
    }

    public class RfSandiBIGroupGetFilterQueryHandler : IRequestHandler<RfSandiBIGroupGetFilterQuery, PagedResponse<IEnumerable<RfSandiBIGroupResponse>>>
    {
        private IGenericRepositoryAsync<RfSandiBIGroup> _core;
        private readonly IMapper _mapper;

        public RfSandiBIGroupGetFilterQueryHandler(IGenericRepositoryAsync<RfSandiBIGroup> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfSandiBIGroupResponse>>> Handle(RfSandiBIGroupGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _core.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfSandiBIGroupResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfSandiBIGroupResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }

}
