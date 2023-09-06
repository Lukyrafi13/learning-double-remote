using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using AutoMapper;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplications.Queries
{
    public class GetLoanApplicationListQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationTableResponse>>>
    {
    }

    public class GetLoanApplicationListQueryHandler : IRequestHandler<GetLoanApplicationListQuery, PagedResponse<IEnumerable<LoanApplicationTableResponse>>>
    {
        private IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IMapper _mapper;

        public GetLoanApplicationListQueryHandler(IGenericRepositoryAsync<LoanApplication> loanApplication, IMapper mapper)
        {
            _loanApplication = loanApplication;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationTableResponse>>> Handle(GetLoanApplicationListQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "Debtor",
                "DebtorCompany",
                "RfProduct",
                "RfOwnerCategory"
            };
            var data = await _loanApplication.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<LoanApplicationTableResponse>>(data.Results);

            return new PagedResponse<IEnumerable<LoanApplicationTableResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}

