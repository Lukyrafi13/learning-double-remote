using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Appraisals.Queries
{
    public class GetAppInfoLoanApplicationCollateralQuery : LoanApplicationApprAppInfoRequests, IRequest<ServiceResponse<LoanApplicationAppInfoApprSurveyorResponse>>
    {
    }

    public class GetAppInfoLoanApplicationCollateralQueryHandler : IRequestHandler<GetAppInfoLoanApplicationCollateralQuery, ServiceResponse<LoanApplicationAppInfoApprSurveyorResponse>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationAppraisal> _appraisal;
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IGenericRepositoryAsync<LoanApplicationFacility> _loanApplicationFacility;
        private readonly IMapper _mapper;

        public GetAppInfoLoanApplicationCollateralQueryHandler(
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

        public async Task<ServiceResponse<LoanApplicationAppInfoApprSurveyorResponse>> Handle(GetAppInfoLoanApplicationCollateralQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var include = new string[]
                {
                    "LoanApplicationCollateral",
                    "LoanApplicationCollateral.RfCollateralBC",
                    "LoanApplicationCollateral.RfDocument",
                    "LoanApplicationCollateral.LoanApplicationCollateralOwner",
                    "LoanApplicationCollateral.LoanApplicationCollateralOwner.RfRelationCollateral",
                    "LoanApplicationCollateral.LoanApplicationCollateralOwner.RfZipCode",
                };
                var data = await _appraisal.GetByPredicate(x => x.AppraisalId == request.AppraisalGuid, include);
                if (data == null)
                {
                    return ServiceResponse<LoanApplicationAppInfoApprSurveyorResponse>.ReturnResultWith204();
                }

                var dataVm = _mapper.Map<LoanApplicationAppInfoApprSurveyorResponse>(data);
                var loanApplicationGuid = data.LoanApplicationId;
                var includesLoanApp = new string[]
                {
                    "RfBranch",
                    "Owner",
                    "RfProduct",
                    "RfBookingBranch",
                    "Debtor",
                    "DebtorCompany",
                    "DebtorCompany.DebtorCompanyLegal",
                };
                var loanAppData = await _loanApplication.GetByPredicate(x => x.Id == loanApplicationGuid, includesLoanApp);
                var loanappid = loanAppData.LoanApplicationId;

                dataVm.Regency = loanAppData.RfBranch.Name;
                dataVm.Branch = loanAppData.RfBranch.Code + " - " + loanAppData.RfBranch.Name;
                dataVm.AccountOfficer = loanAppData.Owner.Nama;
                dataVm.LoanApplicationId = loanAppData.LoanApplicationId;
                dataVm.Product = "BJB " + loanAppData.RfProduct.ProductType;
                dataVm.BookingOffice = loanAppData.RfBookingBranch?.Code + " - " + loanAppData.RfBookingBranch?.Name;

                if (loanAppData.OwnerCategoryId == 1)//Perorangan
                {
                    dataVm.Name = loanAppData.Debtor.Fullname;
                    dataVm.NPWP = loanAppData.Debtor.NPWP;
                    dataVm.NoIdentity = loanAppData.Debtor.NoIdentity;
                    dataVm.DateOfBirth = loanAppData.Debtor.DateOfBirth;
                }
                if (loanAppData.OwnerCategoryId == 2)//Badan Usaha
                {
                    dataVm.Name = loanAppData.DebtorCompany.Name;
                    dataVm.NPWP = "-";
                    dataVm.NoIdentity = "-";
                    dataVm.DateOfBirth = null;
                }

                return ServiceResponse<LoanApplicationAppInfoApprSurveyorResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationAppInfoApprSurveyorResponse>.ReturnException(ex);
            }
        }
    }
}
