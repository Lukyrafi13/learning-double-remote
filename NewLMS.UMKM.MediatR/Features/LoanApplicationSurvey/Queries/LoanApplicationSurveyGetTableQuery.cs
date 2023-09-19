using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.LoanApplicationSurvey;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
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
        private readonly IMapper _mapper;

        public LoanApplicationSurveyGetTableQueryHandler(IGenericRepositoryAsync<LoanApplication> loanApplication, IMapper mapper)
        {
            _loanApplication = loanApplication;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationSurveyTabRespone>>> Handle(LoanApplicationSurveyGetTableQuery request, CancellationToken cancellationToken)
        {
            var filters = request.Filters;
            filters.Add(new RequestFilterParameter()
            {
                Field = "rfStage.StageId",
                ComparisonOperator = "=",
                Type = "string",
                Value = LMSUMKMStages.Survey.StageId.ToString(),
            });
            request.Filters = filters;

            var includes = new string[] {
                "Debtor",
                "DebtorCompany"
            };
            var data = await _loanApplication.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<LoanApplicationSurveyTabRespone>>(data.Results);

            return new PagedResponse<IEnumerable<LoanApplicationSurveyTabRespone>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }

}
