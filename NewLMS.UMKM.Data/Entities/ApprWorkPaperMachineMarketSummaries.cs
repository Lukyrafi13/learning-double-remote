using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class ApprWorkPaperMachineMarketSummaries : BaseEntity
    {
        [Key]
        [Required]
        public Guid ApprWorkPaperMachineMarketSummaryGuid { get; set; }
        [ForeignKey(nameof(LoanApplicationAppraisal))]
        public Guid AppraisalGuid { get; set; }

        /* WEIGHT */
        public decimal? CurrMarketValue { get; set; }
        public double? PctLiquidationValue { get; set; }
        public decimal? LiquidationValue { get; set; }
        public decimal? CurrMarketCostValue { get; set; }
        public double? PctLiquidationCostValue { get; set; }
        public decimal? LiquidationCostValue { get; set; }
        [ForeignKey(nameof(ApproachTypeFK))]
        public Guid? ApproachType { get; set; }

        public virtual LoanApplicationAppraisal LoanApplicationAppraisal { get; set; }
        public virtual ICollection<ApprWorkPaperMachineMarkets> ApprWorkPaperMachineMarkets { get; set; }
        public virtual ICollection<ApprWorkPaperMachineCost> ApprWorkPaperMachineCosts { get; set; }
        public virtual Parameters ApproachTypeFK { get; set; }
    }
}
