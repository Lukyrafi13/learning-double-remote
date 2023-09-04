using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class LoanApplicationStageLog : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationId { get; set; }
        public DateTime? ExecutedDate { get; set; }
        public Guid? ExecutedBy { get; set; }
        public Guid? DispatchedTo { get; set; }

        [ForeignKey(nameof(RfStage))]
        public Guid? StageId { get; set; }

        [ForeignKey(nameof(RfStageTarget))]
        public Guid? TargetStage { get; set; }
        public string? Aging { get; set; }
        public bool? BackStaged { get; set; }

        public virtual LoanApplication LoanApplication { get; set; }
        public virtual RfStage RfStage { get; set; }
        public virtual RfStage RfStageTarget { get; set; }
    }
}