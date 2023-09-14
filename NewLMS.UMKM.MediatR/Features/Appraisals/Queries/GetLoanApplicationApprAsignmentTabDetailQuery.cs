using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.Appraisals
{
    public class GetLoanApplicationApprAsignmentTabDetailQuery : LoanApplicationApprGetDetailRequests, IRequest<ServiceResponse<LoanApplicationApprAsignmentResponse>>
    {
    }

    public class GetLoanApplicationApprAsignmentTabDetailQueryHandler : IRequestHandler<GetLoanApplicationApprAsignmentTabDetailQuery, ServiceResponse<LoanApplicationApprAsignmentResponse>>
    {
        private readonly IGenericRepositoryAsync<Appraisal> _appraisal;
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IGenericRepositoryAsync<LoanApplicationFacility> _loanApplicationFacility;
        private readonly IMapper _mapper;

        public GetLoanApplicationApprAsignmentTabDetailQueryHandler(
            IGenericRepositoryAsync<Appraisal> appraisal, 
            IGenericRepositoryAsync<LoanApplication> loanApplication, 
            IGenericRepositoryAsync<LoanApplicationFacility> loanApplicationFacility, 
            IMapper mapper)
        {
            _appraisal = appraisal;
            _loanApplication = loanApplication;
            _loanApplicationFacility = loanApplicationFacility;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationApprAsignmentResponse>> Handle(GetLoanApplicationApprAsignmentTabDetailQuery request, CancellationToken cancellationToken)
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
                var data = await _appraisal.GetByPredicate(x => x.LoanApplicationCollateralId == request.LoanApplicationCollateralId, include);
                if (data == null)
                {
                    return ServiceResponse<LoanApplicationApprAsignmentResponse>.ReturnResultWith204();
                }

                var loanApplicationGuid = data.LoanApplicationId;
                var includesLoanApp = new string[]
                {
                    "RfBranch",
                    "Debtor",
                    "DebtorCompany",
                    "DebtorCompany.DebtorCompanyLegal",
                };
                var loanAppData =  await _loanApplication.GetByPredicate(x => x.Id == loanApplicationGuid);
                var includesFacility = new string[]
                {
                    "RfSubProduct",
                };
                var loanAppFacilityData = await _loanApplicationFacility.GetListByPredicate(x => x.LoanApplicationId == loanApplicationGuid);

                var dataVm = _mapper.Map<LoanApplicationApprAsignmentResponse>(data);
                dataVm.LoanApplicationInfo.LoanApplicationId = loanAppData.LoanApplicationId;
                dataVm.LoanApplicationInfo.SubProduct = loanAppFacilityData[0].RfSubProduct.SubProductDesc;
                dataVm.LoanApplicationInfo.Branch = loanAppData.RfBranch.Code + loanAppData.RfBranch.Name;
                
                if (loanAppData.OwnerCategoryId == 1)//Perorangan
                {
                    dataVm.LoanApplicationInfo.Name = loanAppData.Debtor.Fullname;
                    dataVm.LoanApplicationInfo.Address = loanAppData.Debtor.Address;
                    dataVm.LoanApplicationInfo.PhoneNumber = loanAppData.Debtor.PhoneNumber;
                }
                if (loanAppData.OwnerCategoryId == 2)//Badan Usaha
                {
                    dataVm.LoanApplicationInfo.Name = loanAppData.DebtorCompany.Name;
                    dataVm.LoanApplicationInfo.SIUPNumber = loanAppData.DebtorCompany.DebtorCompanyLegal.SIUPNumber;
                    dataVm.LoanApplicationInfo.CompanyOld = "-";
                    dataVm.LoanApplicationInfo.Address = loanAppData.DebtorCompany.Address;
                    dataVm.LoanApplicationInfo.PhoneNumber = loanAppData.DebtorCompany.PhoneNumber;
                }

                return ServiceResponse<LoanApplicationApprAsignmentResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationApprAsignmentResponse>.ReturnException(ex);
            }
        }
    }
}
