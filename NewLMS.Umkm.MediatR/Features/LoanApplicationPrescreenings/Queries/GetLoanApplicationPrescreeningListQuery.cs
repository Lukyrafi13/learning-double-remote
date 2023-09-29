using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Constants;
using NewLMS.Umkm.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Domain.Context;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationPrescreenings.Queries
{
    public class GetLoanApplicationPrescreeningListQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationPrescreeningsTableResponse>>>
    {
    }

    public class GetLoanApplicationPrescreeningListQueryHandler : IRequestHandler<GetLoanApplicationPrescreeningListQuery, PagedResponse<IEnumerable<LoanApplicationPrescreeningsTableResponse>>>
    {
        private IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private UserContext _userContext;
        private readonly IMapper _mapper;

        public GetLoanApplicationPrescreeningListQueryHandler(IGenericRepositoryAsync<LoanApplication> loanApplication, IMapper mapper, UserContext userContext)
        {
            _loanApplication = loanApplication;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationPrescreeningsTableResponse>>> Handle(GetLoanApplicationPrescreeningListQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "LoanApplicationStages",
                "RfOwnerCategory",
                "Debtor",
                "DebtorCompany"
            };

            var loanQuery = _userContext.Set<LoanApplication>().AsQueryable();
            foreach (string include in includes)
            {
                loanQuery = loanQuery.Include(include);
            }
            var loans = loanQuery.Where(x => x.LoanApplicationStages.Any(x => x.StageId == UMKMConst.Stages["Prescreening"] && x.Processed == false)).ToList();
            PagedInfoRepositoryResponse info = new PagedInfoRepositoryResponse
            {
                CurrentPage = request.Page,
                Length = request.Length,
                TotalPage = (int)Math.Ceiling(Convert.ToDouble(loans.Count) / request.Length)
            };

            //var data = await _loanApplication.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<LoanApplicationPrescreeningsTableResponse>>(loans);
            return new PagedResponse<IEnumerable<LoanApplicationPrescreeningsTableResponse>>(dataVm, info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
