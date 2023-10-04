using System.Collections.Generic;

namespace NewLMS.Umkm.MediatR.Helpers
{
    public static class IncludesGenerator
    {
        public static List<string> GetLoanApplicationIncludes(string tab)
        {
            List<string> includes = new();
            switch (tab)
            {
                #region IDE
                
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
                        "Prospect",
                        "Owner",
                        "DecisionMaker",
                        "RfBusinessCycle",
                        "RfOwnerCategory",
                        "RfProduct",
                        "RfBranch",
                        "RfBookingBranch",
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
                        "LoanApplicationFacilities",
                        "LoanApplicationFacilities.ApplicationType",
                        "LoanApplicationFacilities.NatureOfCredit",
                        "LoanApplicationFacilities.LoanPurpose",
                        "LoanApplicationFacilities.RfSubProduct",
                        "LoanApplicationFacilities.RfSectorLBU3",
                    };
                    break;
                #endregion

                #region Prescreening

                case "loanapplication_rac":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "LoanApplicationRAC",
                        "RfOwnerCategory",
                        "Debtor.RfMarital",
                        "LoanApplicationFacilities.RfTenor",
                    };
                    break;

                case "prescreening_slik_admin":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                        "Debtor.RfMarital",
                        "SLIKRequest.SLIKRequestDebtors",
                        "LoanApplicationFacilities.RfTenor",
                        "LoanApplicationCreditHistories",
                        "LoanApplicationRAC",
                    };
                    break;

                case "prescreening_duplikasi":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                        "Debtor.RfMarital",
                        "LoanApplicationFacilities.RfTenor",
                        "LoanApplicationRAC",
                    };
                    break;

                case "prescreening_dokumen":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                        "LoanApplicationCollaterals.RfCollateralBC",
                        "Debtor.RfMarital",
                        "LoanApplicationFacilities.RfTenor",
                        "LoanApplicationRAC",
                    };
                    break;
                #endregion  

                //Appraisal Surveyor

                case "surveyor_data_pokok_agunan":
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

                //Survey
                #region Survey
                
                case "survey_ots":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "LoanApplicationFacilities.RfSubProduct",
                        "Debtor",
                        "DebtorCompany",
                        "LoanApplicationFieldSurvey.RelationsWithDebtors",
                        "LoanApplicationFieldSurvey.OwnerCategory",
                        "LoanApplicationFieldSurvey.BusinessLocationStatus",
                        "LoanApplicationFieldSurvey.BusinessFieldKUR",
                        "LoanApplicationFieldSurvey.RfZipCode",
                    };
                    break;

                case "survey_verifikasi_business":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "LoanApplicationFacilities.RfSubProduct",
                        "Debtor",
                        "DebtorCompany",
                        "LoanApplicationVerificationBusiness.BusinessPlaceOwnership",
                        "LoanApplicationVerificationBusiness.OldBusinessLocation",
                    };
                    break;

                case "survey_verifikasi_siklus":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "LoanApplicationFacilities.RfSubProduct",
                        "Debtor",
                        "DebtorCompany",
                        "LoanApplicationVerificationCycle.BusinessLandForm",
                        "LoanApplicationVerificationCycle.BusinessLandArea",
                        "LoanApplicationVerificationCycle.BusinessCapacity",
                    };
                    break;

                case "survey_verifikasi_kebutuhan":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "LoanApplicationFacilities.RfSubProduct",
                        "Debtor",
                        "DebtorCompany",
                        "LoanApplicationVerificationNeed.RfPlacementCountry",
                        "LoanApplicationVerificationNeed.ApplicationType",
                        "LoanApplicationFacilities.RfPlacementCountry",
                        "LoanApplicationFacilities.ApplicationType",
                    };
                    break;
                #endregion
                #region Analyst

                case "analisa_prescreening_slik_admin":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfBookingBranch",
                        "RfOwnerCategory",
                        "SLIKRequest.SLIKRequestDebtors",
                        "LoanApplicationCreditHistories",
                    };
                    break;

                case "analisa_prescreening_dokumen":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfBookingBranch",
                        "RfOwnerCategory",
                    };
                    break;

                case "analisa_prescreening_duplikasi":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfBookingBranch",
                        "RfOwnerCategory",
                    };
                    break;

                case "analisa_prescreening_rac":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfBookingBranch",
                        "RfOwnerCategory",
                        "LoanApplicationRAC",
                    };
                    break;

                case "analisa_verifikasi_usaha":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                        "LoanApplicationVerificationBusiness.BusinessPlaceOwnership",
                        "LoanApplicationVerificationBusiness.OldBusinessLocation",
                    };
                    break;

                case "analisa_verifikasi_siklus":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                        "LoanApplicationVerificationCycle.BusinessLandForm",
                        "LoanApplicationVerificationCycle.BusinessLandArea",
                        "LoanApplicationVerificationCycle.BusinessCapacity",
                    };
                    break;

                case "analisa_verifikasi_kebutuhan":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                        "LoanApplicationVerificationNeed.RfPlacementCountry",
                        "LoanApplicationVerificationNeed.ApplicationType",
                    };
                    break;

                case "analisa_informasi_usaha":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                        "LoanApplicationBusinessInformation.RfBusinessLocation",
                        "LoanApplicationBusinessInformation.RfBusinessPlaceType",
                        "LoanApplicationBusinessInformation.RfBusinessType",
                        "LoanApplicationBusinessInformation.RfBusinessPlaceLocation",
                        "LoanApplicationBusinessInformation.RfBusinessPlaceOwnership.RfBusinessPlaceLocation",
                        "LoanApplicationBusinessInformation.RfMarketingAspect",
                        "LoanApplicationBusinessInformation.RfNumberOfPermanentEmployee",
                        "LoanApplicationBusinessInformation.RfNumberOfDailyEmployee",
                        "LoanApplicationBusinessInformation.RfOtherBusinessDuration",
                    };
                    break;

                case "analisa_hubungan_dengan_bank":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                    };
                    break;

                case "analisa_tujuan_peminjaman":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                    };
                    break;

                case "analisa_kemampuan_membayar":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                    };
                    break;

                case "analisa_hasil_rekomendasi":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                    };
                    break;

                case "analisa_jaminan":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                    };
                    break;

                case "analisa_sandi_ojk":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                    };
                    break;

                case "analisa_informasi_pencairan":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                    };
                    break;

                case "analisa_syarat_kredit":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                    };
                    break;

                case "analisa_complience_sheet":
                    includes = new List<string>()
                    {
                        "RfBranch",
                        "RfBookingBranch",
                        "Owner",
                        "RfProduct",
                        "Debtor",
                        "DebtorCompany",
                        "RfOwnerCategory",
                    };
                    break;

                #endregion

                default:
                    break;
            }
            return includes;
        }
    }
}

