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
                        "RfBranch",
                        "RfBookingBranch",
                        "Debtor",
                        "DebtorCompany",
                        "Owner",
                        "Prospect",
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
                        "Debtor.DebtorCouple.RfZipCode",
                        "Debtor.DebtorCouple.RfJob",
                        "DebtorCompany.DebtorCompanyLegal",
                        "DebtorCompany.RfZipCode",
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

                case "loanapplication_rac":
                    includes = new List<string>()
                    {
                        "RfOwnerCategory",
                        "RfBranch",
                        "RfBookingBranch",
                        "RfProduct",
                        "Owner",
                        "Debtor",
                        "DebtorCompany",
                        "LoanApplicationRAC",
                    };
                    break;

                default:
                    break;
            }
            return includes;
        }
    }
}

