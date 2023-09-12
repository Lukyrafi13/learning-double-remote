using System.Collections.Generic;

namespace NewLMS.UMKM.MediatR.Helpers
{
    public static class IncludesGenerator
    {
        public static List<string> GetLoanApplicationIncludes(string tab)
        {
            List<string> includes = new();
            switch (tab)
            {
                case "initial_data_entry":
                    includes = new List<string>()
                    {
                        "LoanApplicationCreditScoring",
                        "RfBusinessCycle",
                        "RfOwnerCategory",
                        "RfProduct",
                        "Prospect",
                        "RfBranch",
                        "RfBookingBranch",
                        "Debtor",
                        "DebtorCompany",
                        "Owner",
                    };
                    break;

                case "data_permohonan":
                    includes = new List<string>()
                    {
                        "RfOwnerCategory",
                        "RfProduct",
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "Prospect",
                        "Debtor.RfResidenceStatus",
                        "Debtor.RfZipCode",
                        "Debtor.RfJob",
                        "Debtor.RfGender",
                        "Debtor.RfEducation",
                        "Debtor.RfMarital",
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

