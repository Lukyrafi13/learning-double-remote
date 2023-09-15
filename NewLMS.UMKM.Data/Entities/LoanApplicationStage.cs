using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data.Entities
{
    public class LoanApplicationStage : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationId { get; set; }

        [ForeignKey(nameof(RfStage))]
        public Guid StageId { get; set; }

        [ForeignKey(nameof(OwnerRoleId))]
        public Guid OwnerRoleId { get; set; }

        [ForeignKey(nameof(OwnerUser))]
        public Guid OwnerUserId { get; set; }

        public bool Processed { get; set; } = false;
        public DateTime? ProcessedDate { get; set; }

        [ForeignKey(nameof(ProcessedByUser))]
        public Guid? ProcessedBy { get; set; }

        public LoanApplication LoanApplication { get; set; }
        public RfStage RfStage { get; set; }
        public Role OwnerRole { get; set; }
        public User? OwnerUser { get; set; }
        public User? ProcessedByUser { get; set; }
    }
}