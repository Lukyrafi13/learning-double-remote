using System.ComponentModel.DataAnnotations;

namespace NewLMS.UMKM.Data
{
    public class RFStages : BaseEntity
    {
        [Key]
        [Required]
        public int StageId { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }
        public int GroupStage { get; set; }

        [MaxLength(50)]
        public string GroupName { get; set; }


    }
}
