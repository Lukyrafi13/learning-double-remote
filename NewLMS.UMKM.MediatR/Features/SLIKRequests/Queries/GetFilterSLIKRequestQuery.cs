using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.SLIKs;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.SLIKRequests.Queries
{
    public class GetFilterSLIKRequestQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SLIKRequestTableResponse>>>
    {
    }

    public class SIKPGetFilterQueryHandler : IRequestHandler<GetFilterSLIKRequestQuery, PagedResponse<IEnumerable<SLIKRequestTableResponse>>>
    {
        private readonly IGenericRepositoryAsync<SLIKRequest> _slikRequest;
        private readonly IMapper _mapper;

        public SIKPGetFilterQueryHandler(IMapper mapper, IGenericRepositoryAsync<SLIKRequest> slikRequest)
        {
            _mapper = mapper;
            _slikRequest = slikRequest;
        }

        public async Task<PagedResponse<IEnumerable<SLIKRequestTableResponse>>> Handle(GetFilterSLIKRequestQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]
                {
                    "LoanApplication.RfBookingBranch",
                    "LoanApplication.Debtor",
                    "LoanApplication.DebtorCompany",
                    "LoanApplication.RfOwnerCategory",
                    "SLIKRequestDebtors"
                };
            var data = await _slikRequest.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<SLIKRequestTableResponse>>(data.Results);
            return new PagedResponse<IEnumerable<SLIKRequestTableResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
