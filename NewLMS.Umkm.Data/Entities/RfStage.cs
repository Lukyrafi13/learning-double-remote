using System;
using System.ComponentModel.DataAnnotations;

namespace NewLMS.UMKM.Data
{
    public class RfStage : BaseEntity
    {
        [Key]
        [Required]
        public Guid StageId { get; set; }
        [MaxLength(5)]
        public string Code { get; set; }
        public string Description { get; set; }
        public int GroupStage { get; set; }
        public int GroupStageDigiloan { get; set; }
        public string GroupName { get; set; }
        public bool IsShowInTracking { get; set; }


    }
}
