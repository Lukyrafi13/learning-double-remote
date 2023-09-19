using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Appraisals.Queries
{
    public class LoanApplicationApprApprovalGetTableQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationApprSurveyorTableResponse>>>
    {
    }

    public class LoanApplicationApprApprovalGetTableQueryHandler : IRequestHandler<LoanApplicationApprApprovalGetTableQuery, PagedResponse<IEnumerable<LoanApplicationApprSurveyorTableResponse>>>
    {
        private IGenericRepositoryAsync<LoanApplicationAppraisal> _appraisal;
        private IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private IGenericRepositoryAsync<LoanApplicationCollateral> _loanApplicationCollateral;
        private readonly IMapper _mapper;

        public LoanApplicationApprApprovalGetTableQueryHandler(
            IGenericRepositoryAsync<LoanApplicationAppraisal> appraisal,
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IGenericRepositoryAsync<LoanApplicationCollateral> loanApplicationCollateral,
            IMapper mapper)
        {
            _appraisal = appraisal;
            _loanApplication = loanApplication;
            _loanApplicationCollateral = loanApplicationCollateral;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationApprSurveyorTableResponse>>> Handle(LoanApplicationApprApprovalGetTableQuery request, CancellationToken cancellationToken)
        {
            //filter by stage Analyst CR
            var filters = request.Filters;
            filters.Add(new RequestFilterParameter()
            {
                Field = "rfStage.StageId",
                ComparisonOperator = "=",
                Type = "string",
                Value = LMSUMKMStages.AppraisalApproval.StageId.ToString(),
            });
            request.Filters = filters;

            var includes = new string[]
                {
                    "LoanApplicationCollateral",
                };
            var dataColl = await _appraisal.GetPagedReponseAsync(request, includes);
            var dataColVm = _mapper.Map<IEnumerable<AppraisalResponse>>(dataColl.Results);
            var listData = new List<LoanApplicationApprSurveyorTableResponse>();
            foreach (var inData in dataColVm)
            {
                var loanApplicationGuid = inData.LoanApplicationCollateral.LoanApplicationId;
                var includesLoan = new string[]
                {
                    "Debtor",
                    "DebtorCompany",
                };
                var loanApplicationEntity = await _loanApplication.GetByPredicate(x => x.Id == loanApplicationGuid, includesLoan);

                var includesCollateral = new string[]
                {
                    "RfCollateralBC",
                    "RfDocument",
                    "LoanApplicationCollateralOwner",
                };
                var loanApplicationCollateral = await _loanApplicationCollateral.GetByPredicate(x => x.LoanApplicationId == loanApplicationGuid, includesCollateral);

                var initData = new LoanApplicationApprSurveyorTableResponse
                {
                    LoanApplicationCollateralId = loanApplicationCollateral.Id,
                    AppraisalGuid = inData.AppraisalId,
                    DocumentNumber = loanApplicationCollateral.DocumentNumber ?? "-",
                    DocumentName = loanApplicationCollateral.RfDocument?.DocumentDesc ?? null,
                    OwnerName = loanApplicationCollateral.LoanApplicationCollateralOwner?.OwnerName ?? null,
                };

                if (loanApplicationEntity != null)
                {
                    initData.LoanApplicationGuid = loanApplicationGuid;
                    initData.LoanApplicationId = loanApplicationEntity.LoanApplicationId;
                }

                listData.Add(initData);
            }

            return new PagedResponse<IEnumerable<LoanApplicationApprSurveyorTableResponse>>(listData, dataColl.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
