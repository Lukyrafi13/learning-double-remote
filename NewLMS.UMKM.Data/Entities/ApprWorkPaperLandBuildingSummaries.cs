using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class ApprWorkPaperLandBuildingSummaries : BaseEntity
    {
        [Key]
        [Required]
        public Guid ApprWorkPaperLandBuildingSummaryGuid { get; set; }
        [ForeignKey(nameof(LoanApplicationAppraisal))]
        public Guid AppraisalGuid { get; set; }

        /* Weight sub-menu */
        public double? PctTotalIndicatorValue { get; set; }
        public decimal? CurrTotalIndicatorValue { get; set; }
        public decimal? CurrRounding { get; set; }
        public decimal? CurrLandMarketValue { get; set; }
        public decimal? CurrBuildingMarketValue { get; set; }
        public decimal? CurrAssetMarketValue { get; set; }
        /* End */
        public double? PctLandLiquidationValue { get; set; }
        public decimal? LandLiquidationValue { get; set; }
        public double? PctBuildingLiquidationValue { get; set; }
        public decimal? BuildingLiquidationValue { get; set; }

        public virtual LoanApplicationAppraisal LoanApplicationAppraisal { get; set; }
        public virtual ICollection<ApprWorkPaperLandBuildings> ApprWorkPaperLandBuildings { get; set; }
    }
}
