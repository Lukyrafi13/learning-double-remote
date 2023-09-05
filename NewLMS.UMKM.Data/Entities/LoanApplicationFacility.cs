using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data.Entities
{
    public class LoanApplicationFacility : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationId { get; set; }


        [ForeignKey(nameof(ApplicationType))]
        public int ApplicationTypeId { get; set; }

        [ForeignKey(nameof(LoanPurpose))]
        public string LoanPurposeId { get; set; }

        public long SubmittedPlafond { get; set; }

        [ForeignKey(nameof(RfSubProduct))]
        public string SubProductId { get; set; }
        public int LoanTerm { get; set; }
        public string FacilityPurpose { get; set; }
        public string InstallmentType { get; set; }
        public string Interest { get; set; }

        [ForeignKey(nameof(NatureOfCredit))]
        public int NatureOfCreditId { get; set; }
        public long PrincipalInstallment { get; set; }
        public long InterestInstallment { get; set; }

        [ForeignKey(nameof(RfSectorLBU3))]
        public string? SectorLBU3Code { get; set; }


        public virtual LoanApplication LoanApplication { get; set; }
        public virtual RfParameterDetail ApplicationType { get; set; }
        public virtual RfParameterDetail NatureOfCredit { get; set; }
        public virtual RfLoanPurpose LoanPurpose { get; set; }
        public virtual RfSubProduct RfSubProduct { get; set; }
        public virtual RfSectorLBU3 RfSectorLBU3 { get; set; }
    }
}
