using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class ApprLiquidation : BaseEntity
    {
        [Key]
        public Guid LiquidationGuid { get; set; }
        [ForeignKey(nameof(LoanApplicationAppraisal))]
        public Guid AppraisalGuid { get; set; }
        public string LiquidationType { get; set; }
        public string LiquidationItem { get; set; }
        public string LiquidationOption { get; set; }
        public double? LiquidationScore { get; set; }

        public virtual LoanApplicationAppraisal LoanApplicationAppraisal { get; set; }
        public virtual MLiquidationItem MLiquidationItem { get; set; }
        public virtual MLiquidationOption MLiquidationOption { get; set; }
    }
}
