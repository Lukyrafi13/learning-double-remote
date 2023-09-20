using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Appraisals.Queries
{
    public class GetLoanAppApprSurveyorTabDetailQuery : LoanApplicationApprGetDetailRequests, IRequest<ServiceResponse<LoanApplicationApprSurveyorResponse>>
    {
    }

    public class GetLoanAppApprSurveyorTabDetailQueryHandler : IRequestHandler<GetLoanAppApprSurveyorTabDetailQuery, ServiceResponse<LoanApplicationApprSurveyorResponse>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationAppraisal> _appraisal;
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IGenericRepositoryAsync<LoanApplicationFacility> _loanApplicationFacility;
        private readonly IMapper _mapper;

        public GetLoanAppApprSurveyorTabDetailQueryHandler(
            IGenericRepositoryAsync<LoanApplicationAppraisal> appraisal, 
            IGenericRepositoryAsync<LoanApplication> loanApplication, 
            IGenericRepositoryAsync<LoanApplicationFacility> loanApplicationFacility, 
            IMapper mapper)
        {
            _appraisal = appraisal;
            _loanApplication = loanApplication;
            _loanApplicationFacility = loanApplicationFacility;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationApprSurveyorResponse>> Handle(GetLoanAppApprSurveyorTabDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var include = new string[]
                {
                    "LoanApplication.RfOwnerCategory",
                    "LoanApplicationCollateral",
                    "LoanApplicationCollateral.RfCollateralBC",
                    "LoanApplicationCollateral.RfDocument",
                    "LoanApplicationCollateral.LoanApplicationCollateralOwner",
                    "LoanApplicationCollateral.LoanApplicationCollateralOwner.RfRelationCollateral",
                    "LoanApplicationCollateral.LoanApplicationCollateralOwner.RfZipCode",
                };
                var data = await _appraisal.GetByPredicate(x => x.LoanApplicationCollateralId == request.LoanApplicationCollateralId, include);
                if (data == null)
                {
                    return ServiceResponse<LoanApplicationApprSurveyorResponse>.ReturnResultWith204();
                }

                var dataVm = _mapper.Map<LoanApplicationApprSurveyorResponse>(data);
                var loanApplicationGuid = data.LoanApplicationId;
                var includesLoanApp = new string[]
                {
                    "RfOwnerCategory",
                    "RfBranch",
                    "Debtor",
                    "DebtorCompany",
                    "DebtorCompany.DebtorCompanyLegal",
                };
                var loanAppData = await _loanApplication.GetByPredicate(x => x.Id == loanApplicationGuid, includesLoanApp);
                var includesFacility = new string[]
                {
                    "RfSubProduct",
                };
                var loanAppFacilityData = await _loanApplicationFacility.GetListByPredicate(x => x.LoanApplicationId == loanApplicationGuid, includesFacility);
                var loanappid = loanAppData.LoanApplicationId;

                dataVm.LoanApplicationInfo.LoanApplicationId = loanAppData.LoanApplicationId;
                dataVm.LoanApplicationInfo.SubProduct = loanAppFacilityData[0].RfSubProduct.SubProductDesc;
                dataVm.LoanApplicationInfo.Branch = loanAppData.RfBranch.Code + " - " + loanAppData.RfBranch.Name;

                if (loanAppData.OwnerCategoryId == 1)//Perorangan
                {
                    dataVm.LoanApplicationInfo.Name = loanAppData.Debtor.Fullname;
                    dataVm.LoanApplicationInfo.Address = loanAppData.Debtor.Address;
                    dataVm.LoanApplicationInfo.PhoneNumber = loanAppData.Debtor.PhoneNumber;
                    dataVm.LoanApplicationInfo.NPWP = loanAppData.Debtor.NPWP;
                }
                if (loanAppData.OwnerCategoryId == 2)//Badan Usaha
                {
                    dataVm.LoanApplicationInfo.Name = loanAppData.DebtorCompany.Name;
                    dataVm.LoanApplicationInfo.SIUPDate = loanAppData.DebtorCompany.DebtorCompanyLegal.SIUPDate;
                    dataVm.LoanApplicationInfo.SIUPNumber = loanAppData.DebtorCompany.DebtorCompanyLegal.SIUPNumber;
                    dataVm.LoanApplicationInfo.Address = loanAppData.DebtorCompany.Address;
                    dataVm.LoanApplicationInfo.PhoneNumber = loanAppData.DebtorCompany.PhoneNumber;
                    dataVm.LoanApplicationInfo.PhoneNumber = loanAppData.DebtorCompany.PhoneNumber;
                }

                return ServiceResponse<LoanApplicationApprSurveyorResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationApprSurveyorResponse>.ReturnException(ex);
            }
        }
    }
}
