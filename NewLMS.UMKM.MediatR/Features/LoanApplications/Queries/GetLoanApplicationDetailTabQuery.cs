using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Prospects;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using System.Collections.Generic;

namespace NewLMS.UMKM.MediatR.Features.Prospects.Queries
{
    public class GetLoanApplicationDetailTabQuery : LoanApplicationGetDetailTabRequest, IRequest<ServiceResponse<LoanApplicationIDEResponse>>
    {
    }

    public class GetLoanApplicationDetailTabQueryHandler : IRequestHandler<GetLoanApplicationDetailTabQuery, ServiceResponse<LoanApplicationIDEResponse>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IMapper _mapper;

        public GetLoanApplicationDetailTabQueryHandler(IGenericRepositoryAsync<LoanApplication> loanApplication, IMapper mapper)
        {
            _loanApplication = loanApplication;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationIDEResponse>> Handle(GetLoanApplicationDetailTabQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationIncludes = GetLoanApplicationIncludes(request.Tab);
                var data = await _loanApplication.GetByIdAsync(request.Id, "Id", loanApplicationIncludes.ToArray());
                if (data == null)
                {

                    return ServiceResponse<LoanApplicationIDEResponse>.ReturnResultWith204();
                }
                else
                {
                    data.MappingTab = request.Tab;
                }

                var dataVm = _mapper.Map<LoanApplicationIDEResponse>(data);
                if(dataVm.Info.OwnerCategoryId == 1)
                {
                    dataVm.Info.FullName = data.Debtor.Fullname;
                }
                if (dataVm.Info.OwnerCategoryId == 2)
                {
                    dataVm.Info.FullName = data.DebtorCompany.Name;
                }

                return ServiceResponse<LoanApplicationIDEResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationIDEResponse>.ReturnException(ex);
            }
        }

        private static List<string> GetLoanApplicationIncludes(string tab)
        {
            List<string> includes = new();
            switch (tab)
            {
                case "initial_data_entry":
                    includes = new List<string>()
                    {
                        "LoanApplicationCreditScoring.ScoResidentialReputation",
                        "LoanApplicationCreditScoring.ScoBankRelation",
                        "LoanApplicationCreditScoring.ScoBJBCreditHistory",
                        "LoanApplicationCreditScoring.ScoTransacMethod",
                        "LoanApplicationCreditScoring.ScoAverageAccBalance",
                        "LoanApplicationCreditScoring.ScoNeedLevel",
                        "LoanApplicationCreditScoring.ScoFinanceManager",
                        "LoanApplicationCreditScoring.ScoBusinesLocation",
                        "LoanApplicationCreditScoring.ScoOtherPartyDebt",
                        "LoanApplicationCreditScoring.ScoCollateral",
                        "RfProduct",
                        "RfOwnerCategory",
                        "RfBusinessCycle",
                        "RfBranch",
                        "RfBookingBranch",
                        "Debtor",
                        "DebtorCompany",
                    };
                    break;

                case "data_permohonan":
                    includes = new List<string>()
                    {
                        "Debtor.RfResidenceStatus",
                        "Debtor.RfZipCode",
                        "Debtor.RfJob",
                        "Debtor.RfGender",
                        "Debtor.RfEducation",
                        "Debtor.RfMarital",
                        "Debtor.DebtorCouple.RfZipCode",
                        "Debtor.DebtorCouple.RfJob",
                        "DebtorCompany.DebtorCompanyLegal",
                        "DebtorCompany.DebtorCompanyLegal",
                        "DebtorEmergency.RfZipCode",
                    };
                    break;

                case "data_key_person":
                    includes = new List<string>()
                    {
                        "LoanApplicationKeyPersons"
                    };
                    break;

                case "data_agunan":
                    includes = new List<string>()
                    {
                        "LoanApplicationCollaterals.RfZipCode",
                        "LoanApplicationCollaterals.LoanApplicationCollateralOwner.RfResidenceStatus",
                        "LoanApplicationCollaterals.LoanApplicationCollateralOwner.RfZipCode",
                        "LoanApplicationCollaterals.LoanApplicationCollateralOwner.RfJob",
                        "LoanApplicationCollaterals.LoanApplicationCollateralOwner.RfGender",
                        "LoanApplicationCollaterals.LoanApplicationCollateralOwner.RfEducation",
                        "LoanApplicationCollaterals.LoanApplicationCollateralOwner.RfMarital",
                    };
                    break;

                case "informasi_fasilitas":
                    includes = new List<string>()
                    {
                        "LoanApplicationFacilities",
                        "LoanApplicationFacilities.ApplicationType",
                        "LoanApplicationFacilities.NatureOfCredit",
                        "LoanApplicationFacilities.LoanPurpose",
                        "LoanApplicationFacilities.RfSubProduct",
                        "LoanApplicationFacilities.RfSectorLBU3",
                    };
                    break;

                default:
                    break;
            }
            return includes;
        }
    }
}