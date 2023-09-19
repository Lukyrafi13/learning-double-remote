using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class ApprBuildingFloorDetails : BaseEntity
    {
        [Key]
        [Required]
        public Guid BuildingFloorDetailGuid { get; set; }
        [ForeignKey(nameof(ApprBuildingFloors))]
        public Guid ApprBuildingFloorGuid { get; set; }
        public string FloorDescription { get; set; }
        public string RoomName { get; set; }
        public double? RoomArea { get; set; }
        public virtual ApprBuildingFloors ApprBuildingFloors { get; set; }
    }
}
