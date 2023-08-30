using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class LoanApplicationStageLogs : BaseEntity
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

        public LoanApplication LoanApplication { get; set; }
        public RfStage RfStage { get; set; }
        public RfStage RfStageTarget { get; set; }

    }
}