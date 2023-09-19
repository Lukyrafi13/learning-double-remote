using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using AutoMapper;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplications.Queries
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

