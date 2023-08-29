using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class ProspectStageLogs : BaseEntity
    {
        [Key]
        [Required]
        public Guid LoanApplicationStageLogId { get; set; }

        [ForeignKey(nameof(Prospect))]
        public Guid ProspectId { get; set; }        
        public int StageId { get; set; }
        public Guid? RFRejectId { get; set; }
        
        public Prospect Prospect { get; set; }

        [ForeignKey("StageId")]
        public RFStages RFStages { get; set; }
        
        [ForeignKey("RFRejectId")]
        public RFReject Alasan { get; set; }
        public DateTime? ExecutedDate { get; set; }

        public string ExecutedBy { get; set; }

    }
}