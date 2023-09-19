using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class CollateralInsurance : BaseEntity
    {
        [Key]
        [Required]
        public Guid CollateralInsuranceGuid { get; set; }
        [ForeignKey(nameof(LoanApplicationCollateral))]
        public Guid LoanApplicationCollateralGuid { get; set; }
        public string Insurance { get; set; }                       // NAMA ASURANSI, BROKER
        public string Coverage { get; set; }                        // COVERAGE
        public int? Tenor { get; set; }
        public decimal? CoverageValue { get; set; }
        public decimal? EstimatePremi { get; set; }                 // PERKIRAAN PREMI ASURANSI
        public decimal? PolicyCost { get; set; }                    // BIAYA POLISI
        public decimal? LifeInsuranceCommission { get; set; }       // KOMISI ASURANSI JIWA
        //[ForeignKey(nameof(RFInsuranceRateTemplateMapping))]
        public string TemplateMappingCode { get; set; }             // RATE

        public virtual LoanApplicationCollateral LoanApplicationCollateral { get; set; }
        //public virtual RFInsuranceCompanyRateTemplete RFInsuranceCompanyRateTemplete { get; set; }
        //public virtual RFInsuranceRateTemplateMapping RFInsuranceRateTemplateMapping { get; set; }
    }
}
