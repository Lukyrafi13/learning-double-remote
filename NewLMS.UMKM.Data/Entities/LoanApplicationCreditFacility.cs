using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class LoanApplicationCreditFacility : BaseEntity
    {
        public Guid Id { get; set; }
        public float Plafond { get; set; }
        public string UsagePurpose { get; set; }
        public string InstallmentType { get; set; }
        public float InterestRate { get; set; }
        public float PrimaryInstallment { get; set; }
        public float InterestInstallment { get; set; }
        public float Installment => PrimaryInstallment + InterestInstallment;
        [ForeignKey(nameof(SubSubSector))]
        public Guid LoanApplicationId { get; set; }
        [ForeignKey(nameof(RfAppType))]
        public int? RfAppTypeId { get; set; }
        [ForeignKey(nameof(RfLoanPurpose))]
        public Guid? RFLoanPurposeId { get; set; }
        [ForeignKey(nameof(RfSubProduct))]
        public Guid? RFSubProductId { get; set; }
        [ForeignKey(nameof(RfPlacementCountry))]
        public Guid? RFPlacementCountryId { get; set; }
        [ForeignKey(nameof(CreditTenor))]
        public Guid? RFTenorId { get; set; }
        [ForeignKey(nameof(CreditBehavior))]
        public Guid? RFCreditBehaviorId { get; set; }
        [ForeignKey(nameof(Sector))]
        public string RfSectorLBU1Code { get; set; }
        [ForeignKey(nameof(SubSector))]
        public string RfSectorLBU2Code { get; set; }
        [ForeignKey(nameof(SubSubSector))]
        public string RfSectorLBU3Code { get; set; }

        
        public LoanApplication LoanApplication { get; set; }
        public RfParameterDetail RfAppType { get; set; }
        public RFLoanPurpose RfLoanPurpose { get; set; }    
        public RFSubProduct RfSubProduct { get; set; }  
        public RFPlacementCountry RfPlacementCountry { get; set; }
        public RfSectorLBU1 Sector { get; set; }
        public RfSectorLBU2 SubSector { get; set; }
        public RfSectorLBU3 SubSubSector { get; set; }
        public RfParameterDetail CreditBehavior { get; set; }
        public RFTenor CreditTenor { get; set;}
        
    }
}