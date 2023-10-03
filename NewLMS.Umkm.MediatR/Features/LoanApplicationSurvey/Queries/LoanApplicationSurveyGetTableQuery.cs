using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Constants;
using NewLMS.Umkm.Data.Dto.LoanApplicationSurvey;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Domain.Context;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationSurvey.Queries
{
    public class LoanApplicationSurveyGetTableQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationSurveyTabRespone>>>
    {
    }

    public class LoanApplicationSurveyGetTableQueryHandler : IRequestHandler<LoanApplicationSurveyGetTableQuery, PagedResponse<IEnumerable<LoanApplicationSurveyTabRespone>>>
    {
        private IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private UserContext _userContext;
        private readonly IMapper _mapper;

        public LoanApplicationSurveyGetTableQueryHandler(
            IGenericRepositoryAsync<LoanApplication> loanApplication, 
            UserContext userContext, 
            IMapper mapper)
        {
            _loanApplication = loanApplication;
            _userContext = userContext;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationSurveyTabRespone>>> Handle(LoanApplicationSurveyGetTableQuery request, CancellationToken cancellationToken)
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
            var loans = loanQuery.Where(x => x.LoanApplicationStages.Any(x => x.StageId == UMKMConst.Stages["Survey"] && x.Processed == false)).ToList();
            PagedInfoRepositoryResponse info = new PagedInfoRepositoryResponse
            {
                CurrentPage = request.Page,
                Length = request.Length,
                TotalPage = (int)Math.Ceiling(Convert.ToDouble(loans.Count) / request.Length)
            };

            //var data = await _loanApplication.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<LoanApplicationSurveyTabRespone>>(loans);
            return new PagedResponse<IEnumerable<LoanApplicationSurveyTabRespone>>(dataVm, info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }

}
