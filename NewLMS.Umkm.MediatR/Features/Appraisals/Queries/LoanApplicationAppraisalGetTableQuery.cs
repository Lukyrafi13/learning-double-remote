using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Appraisals.Queries
{
    public class LoanApplicationAppraisalGetTableQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationAppraisalTableResponse>>>
    {
    }

    public class LoanApplicationAppraisalGetTableQueryHandler : IRequestHandler<LoanApplicationAppraisalGetTableQuery, PagedResponse<IEnumerable<LoanApplicationAppraisalTableResponse>>>
    {
        private IGenericRepositoryAsync<LoanApplicationAppraisal> _appraisal;
        private IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private IGenericRepositoryAsync<LoanApplicationFacility> _loanApplicationFacility;
        private IGenericRepositoryAsync<LoanApplicationCollateral> _loanApplicationCollateral;
        private readonly IMapper _mapper;

        public LoanApplicationAppraisalGetTableQueryHandler(
            IGenericRepositoryAsync<LoanApplicationAppraisal> appraisal, 
            IGenericRepositoryAsync<LoanApplication> loanApplication, 
            IGenericRepositoryAsync<LoanApplicationFacility> loanApplicationFacility, 
            IGenericRepositoryAsync<LoanApplicationCollateral> loanApplicationCollateral, 
            IMapper mapper)
        {
            _appraisal = appraisal;
            _loanApplication = loanApplication;
            _loanApplicationFacility = loanApplicationFacility;
            _loanApplicationCollateral = loanApplicationCollateral;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationAppraisalTableResponse>>> Handle(LoanApplicationAppraisalGetTableQuery request, CancellationToken cancellationToken)
        {
            
            var filters = request.Filters;
            filters.Add(new RequestFilterParameter()
            {
                Field = "rfStage.StageId",
                ComparisonOperator = "=",
                Type = "string",
                Value = LMSUMKMStages.AppraisalAsignment.StageId.ToString(),
            });
            request.Filters = filters;

            var includes = new string[]
                {
                    "LoanApplicationCollateral",
                };
            var dataColl = await _appraisal.GetPagedReponseAsync(request, includes);
            var dataColVm = _mapper.Map<IEnumerable<AppraisalResponse>>(dataColl.Results);
            var listData = new List<LoanApplicationAppraisalTableResponse>();
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
                };
                var loanApplicationCollateral = await _loanApplicationCollateral.GetByPredicate(x => x.LoanApplicationId == loanApplicationGuid, includesCollateral);

                var initData = new LoanApplicationAppraisalTableResponse
                {
                    Collateral = loanApplicationCollateral.RfCollateralBC.CollateralDesc,
                    LoanApplicationCollateralId = loanApplicationCollateral.Id,
                    AppraisalGuid = inData.AppraisalId,
                };

                if (loanApplicationEntity != null)
                {
                    initData.LoanApplicationGuid = loanApplicationGuid;
                    initData.LoanApplicationId = loanApplicationEntity.LoanApplicationId;
                    if (loanApplicationEntity.OwnerCategoryId == 1)//Perorangan
                    {
                        initData.DebtorName = loanApplicationEntity.Debtor.Fullname;
                    }
                    if (loanApplicationEntity.OwnerCategoryId == 2)//Badan Usaha
                    {
                        initData.DebtorName = loanApplicationEntity.DebtorCompany.Name;
                    }
                    initData.EntryDate = loanApplicationEntity.CreatedDate;
                }

                var includesLoanFacility = new string[]
                {
                    "RfSubProduct",
                };
                var loanApplicationFacility = await _loanApplicationFacility.GetListByPredicate(x => x.LoanApplicationId == loanApplicationGuid, includesLoanFacility);
                if (loanApplicationFacility != null && loanApplicationFacility.Count > 0)
                {
                    initData.CreditSubProduct = loanApplicationFacility[0].RfSubProduct.SubProductDesc;
                }

                listData.Add(initData);
            }

            return new PagedResponse<IEnumerable<LoanApplicationAppraisalTableResponse>>(listData, dataColl.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
