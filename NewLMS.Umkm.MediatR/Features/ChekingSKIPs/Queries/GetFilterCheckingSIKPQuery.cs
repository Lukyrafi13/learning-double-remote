using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.ChekingSIKPs;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.ChekingSKIPs.Queries
{
    public class GetFilterCheckingSIKPQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<ChekingSIKPHistoryResponse>>>
    {
    }

    public class GetFilterCheckingSIKPQueryHandler : IRequestHandler<GetFilterCheckingSIKPQuery, PagedResponse<IEnumerable<ChekingSIKPHistoryResponse>>>
    {
        private IGenericRepositoryAsync<SIKPHistory> _sikpHistory;
        private readonly IMapper _mapper;

        public GetFilterCheckingSIKPQueryHandler(IMapper mapper, IGenericRepositoryAsync<SIKPHistory> sikpHistory)
        {
            _mapper = mapper;
            _sikpHistory = sikpHistory;
        }

        public async Task<PagedResponse<IEnumerable<ChekingSIKPHistoryResponse>>> Handle(GetFilterCheckingSIKPQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]
                {
                    //"SIKPHistoryDetails"
                };
            var data = await _sikpHistory.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<ChekingSIKPHistoryResponse>>(data.Results);
            return new PagedResponse<IEnumerable<ChekingSIKPHistoryResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
