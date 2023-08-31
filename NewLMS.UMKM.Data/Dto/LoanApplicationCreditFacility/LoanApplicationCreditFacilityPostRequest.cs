using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationCreditFacilities
{
    public class LoanApplicationCreditFacilityPostRequestDto
    {
        
        public float Plafond { get; set; }
        public string UsagePurpose { get; set; }
        public string InstallmentType { get; set; }
        public float InterestRate { get; set; }
        public float PrimaryInstallment { get; set; }
        public float InterestInstallment { get; set; }
        public float Installment => PrimaryInstallment + InterestInstallment;
        public Guid LoanApplicationId { get; set; }
        public int? RfAppTypeId { get; set; }
        public Guid? RFLoanPurposeId { get; set; }
        public Guid? RFSubProductId { get; set; }
        public Guid? RFPlacementCountryId { get; set; }
        public Guid? RFTenorId { get; set; }
        public Guid? RFCreditBehaviorId { get; set; }
        public string RfSectorLBU1Code { get; set; }
        public string RfSectorLBU2Code { get; set; }
        public string RfSectorLBU3Code { get; set; }
    }
}
