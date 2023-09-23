using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class ApprWorkPaperShopApartmentSummaries : BaseEntity
    {
        [Key]
        [Required]
        public Guid ApprWorkPaperShopApartmentSummaryGuid { get; set; }
        [ForeignKey(nameof(LoanApplicationAppraisal))]
        public Guid AppraisalGuid { get; set; }

        /* WEIGHT */
        public decimal? CurrShopValue { get; set; }
        public decimal? CurrShopMarketValue { get; set; }
        public double? PctLiquidationValue { get; set; }
        public decimal? LiquidationValue { get; set; }

        public virtual LoanApplicationAppraisal LoanApplicationAppraisal { get; set; }
        public virtual ICollection<ApprWorkPaperShopApartments> ApprWorkPaperShopApartments { get; set; }
    }
}
