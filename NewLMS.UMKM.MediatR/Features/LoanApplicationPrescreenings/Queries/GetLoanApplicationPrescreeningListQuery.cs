using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationPrescreenings.Queries
{
    public class GetLoanApplicationPrescreeningListQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationPrescreeningsTableResponse>>>
    {
    }

    public class GetLoanApplicationPrescreeningListQueryHandler : IRequestHandler<GetLoanApplicationPrescreeningListQuery, PagedResponse<IEnumerable<LoanApplicationPrescreeningsTableResponse>>>
    {
        private IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IMapper _mapper;

        public GetLoanApplicationPrescreeningListQueryHandler(IGenericRepositoryAsync<LoanApplication> loanApplication, IMapper mapper)
        {
            _loanApplication = loanApplication;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationPrescreeningsTableResponse>>> Handle(GetLoanApplicationPrescreeningListQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfOwnerCategory",
                "Debtor",
                "DebtorCompany"
            };
            var data = await _loanApplication.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<LoanApplicationPrescreeningsTableResponse>>(data.Results);
            return new PagedResponse<IEnumerable<LoanApplicationPrescreeningsTableResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
