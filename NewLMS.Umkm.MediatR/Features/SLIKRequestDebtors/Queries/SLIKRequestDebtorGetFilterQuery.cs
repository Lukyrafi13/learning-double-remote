using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.SIKPs;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SLIKRequestDebtors.Queries
{
    public class SLIKRequestDebtorGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SIKPTableResponse>>>
    {
    }

    public class SLIKRequestDebtorGetFilterQueryHandler : IRequestHandler<SLIKRequestDebtorGetFilterQuery, PagedResponse<IEnumerable<SIKPTableResponse>>>
    {
        private IGenericRepositoryAsync<Data.Entities.SIKP> _sikp;
        private readonly IMapper _mapper;

        public SLIKRequestDebtorGetFilterQueryHandler(IMapper mapper, IGenericRepositoryAsync<Data.Entities.SIKP> sikp)
        {
            _mapper = mapper;
            _sikp = sikp;
        }

        public async Task<PagedResponse<IEnumerable<SIKPTableResponse>>> Handle(SLIKRequestDebtorGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]
                {
                    "SIKPRequest",
                    "LoanApplication"
                };
            var data = await _sikp.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<SIKPTableResponse>>(data.Results);
            return new PagedResponse<IEnumerable<SIKPTableResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
