using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class ApprBuildingFloors : BaseEntity
    {
        [Key]
        [Required]
        public Guid BuildingFloorGuid { get; set; }
        [ForeignKey(nameof(ApprBuildingTemplates))]
        public Guid ApprBuildingTemplateGuid { get; set; }
        public string FloorDescription { get; set; }
        public int? TotalRoom { get; set; }
        public double? TotalArea { get; set; }
        public virtual ApprBuildingTemplates ApprBuildingTemplates { get; set; }
        public virtual ICollection<ApprBuildingFloorDetails> ApprBuildingFloorDetails { get; set; }
    }
}
