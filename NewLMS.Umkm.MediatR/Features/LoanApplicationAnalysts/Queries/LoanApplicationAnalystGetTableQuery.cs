using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Constants;
using NewLMS.Umkm.Data.Dto.LoanApplicationAnalysts;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Domain.Context;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationAnalysts.Queries
{
    public class LoanApplicationAnalystGetTableQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationAnalystTableResponse>>>
    {
    }

    public class LoanApplicationAnalystGetTableQueryHandler : IRequestHandler<LoanApplicationAnalystGetTableQuery, PagedResponse<IEnumerable<LoanApplicationAnalystTableResponse>>>
    {
        private IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private UserContext _userContext;
        private readonly IMapper _mapper;

        public LoanApplicationAnalystGetTableQueryHandler(
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            UserContext userContext,
            IMapper mapper)
        {
            _loanApplication = loanApplication;
            _userContext = userContext;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationAnalystTableResponse>>> Handle(LoanApplicationAnalystGetTableQuery request, CancellationToken cancellationToken)
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
            var loans = loanQuery.Where(x => x.LoanApplicationStages.Any(x => x.StageId == UMKMConst.Stages["Analisa"] && x.Processed == false)).ToList();
            PagedInfoRepositoryResponse info = new PagedInfoRepositoryResponse
            {
                CurrentPage = request.Page,
                Length = request.Length,
                TotalPage = (int)Math.Ceiling(Convert.ToDouble(loans.Count) / request.Length)
            };

            var dataVm = _mapper.Map<IEnumerable<LoanApplicationAnalystTableResponse>>(loans);
            return new PagedResponse<IEnumerable<LoanApplicationAnalystTableResponse>>(dataVm, info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
