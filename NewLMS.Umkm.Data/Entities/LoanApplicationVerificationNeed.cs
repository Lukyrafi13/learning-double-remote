using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Entities
{
    public class LoanApplicationVerificationNeed : BaseEntity
    {
        [Key]
        [Required]
        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationId { get; set; }
        public string PPTKISName { get; set; }

        [ForeignKey(nameof(RfPlacementCountry))]
        public string PlaceMentCountryCode { get; set; }

        public double? LongPlacementTime { get; set; }
        public double? ExtendtedTime { get; set; }

        [ForeignKey(nameof(ApplicationType))]
        public int? ApplicationTypeCode { get; set; }
        
        public string BirthCertificateNumber { get; set; }
        public double? MonthlyIncomeForeignCurrency { get; set; }
        public double? ExchangeRate { get; set; }
        public double? MonthlyIncomeRupiahCurrency { get; set; }
        public string PassportNumber { get; set; }
        public string VisaNumber { get; set; }

        public virtual LoanApplication LoanApplication { get; set; }
        public virtual RfPlacementCountry RfPlacementCountry { get; set; }
        public virtual RfParameterDetail ApplicationType { get; set; }
    }
}
