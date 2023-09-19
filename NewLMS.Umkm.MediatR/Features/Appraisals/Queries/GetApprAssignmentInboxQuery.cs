using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Appraisals.Queries
{
    public class GetApprAssignmentInboxQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<ApprAssignmentDataListResponse>>>
    {

    }
    public class GetApprAssignmentInboxQueryHandler : IRequestHandler<GetApprAssignmentInboxQuery, PagedResponse<IEnumerable<ApprAssignmentDataListResponse>>>
    {

        private IGenericRepositoryAsync<LoanApplicationCollateral> _loanApplicationCollateral;
        private IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private IGenericRepositoryAsync<LoanApplicationFacility> _loanApplicationFacility;
        private IMapper _mapper;

        public GetApprAssignmentInboxQueryHandler(
            IGenericRepositoryAsync<LoanApplicationCollateral> loanApplicationCollateral, 
            IGenericRepositoryAsync<LoanApplication> loanApplication, 
            IGenericRepositoryAsync<LoanApplicationFacility> loanApplicationFacility, 
            IMapper mapper)
        {
            _loanApplicationCollateral = loanApplicationCollateral;
            _loanApplication = loanApplication;
            _loanApplicationFacility = loanApplicationFacility;
            _mapper = mapper;
        }
        public async Task<PagedResponse<IEnumerable<ApprAssignmentDataListResponse>>> Handle(GetApprAssignmentInboxQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]
                {
                    "RfCollateralBC"
                };
            var dataColl = await _loanApplicationCollateral.GetPagedReponseAsync(request, includes);
            var dataColVm = _mapper.Map<IEnumerable<LoanApplicationCollateralResponse>>(dataColl.Results);
            var listData = new List<ApprAssignmentDataListResponse>();
            foreach (var inData in dataColVm)
            {
                var initData = new ApprAssignmentDataListResponse
                {
                    Collateral = inData.RfCollateralBC.CollateralDesc
                };

                var includesLoan = new string[]
                {
                    "Debtor",
                    "DebtorCompany",
                };
                var loanApplicationEntity = await _loanApplication.GetListByPredicate(x => x.Id == inData.LoanApplicationId, includesLoan);
                if (loanApplicationEntity != null && loanApplicationEntity.Count > 0)
                {
                    initData.LoanApplicationGuid = loanApplicationEntity[0].Id;
                    initData.LoanApplicationId = loanApplicationEntity[0].LoanApplicationId;
                    if (loanApplicationEntity[0].OwnerCategoryId == 1)//Perorangan
                    {
                        initData.DebtorName = loanApplicationEntity[0].Debtor.Fullname;
                    }
                    if (loanApplicationEntity[0].OwnerCategoryId == 2)//Badan Usaha
                    {
                        initData.CompanyName = loanApplicationEntity[0].DebtorCompany.Name;
                    }
                    initData.EntryDate = loanApplicationEntity[0].CreatedDate;
                    initData.LoanApplicationCollateralGuid = inData.Id;
                }

                var includesLoanFacility = new string[]
                {
                    "RfSubProduct",
                };
                var loanApplicationFacility = await _loanApplicationFacility.GetListByPredicate(x => x.LoanApplicationId == initData.LoanApplicationGuid, includesLoanFacility);
                if (loanApplicationFacility != null && loanApplicationFacility.Count > 0)
                {
                    initData.CreditSubProduct = loanApplicationFacility[0].RfSubProduct.SubProductDesc;
                }

                listData.Add(initData);
            }

            return new PagedResponse<IEnumerable<ApprAssignmentDataListResponse>>(listData, dataColl.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
