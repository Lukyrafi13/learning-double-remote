using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfSandiBI;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfSandiBIs.Queries.GetFilterRfSandiBIs
{
    public class RfSandiBIsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfSandiBIResponse>>>
    {
    }

    public class RfSandiBIsGetFilterQueryHandler : IRequestHandler<RfSandiBIsGetFilterQuery, PagedResponse<IEnumerable<RfSandiBIResponse>>>
    {
        private IGenericRepositoryAsync<RfSandiBI> _core;
        private readonly IMapper _mapper;

        public RfSandiBIsGetFilterQueryHandler(IGenericRepositoryAsync<RfSandiBI> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfSandiBIResponse>>> Handle(RfSandiBIsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] { "RfSandiBIGroup" };
            var data = await _core.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfSandiBIResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfSandiBIResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
