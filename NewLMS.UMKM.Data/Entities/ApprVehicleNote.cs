using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class ApprVehicleNote : BaseEntity
    {
        [Key]
        [Required]
        public Guid VehicleNoteGuid { get; set; }

        [ForeignKey(nameof(VehicleTemplate))]
        public Guid ApprVehicleTemplateGuid { get; set; }
        public virtual ApprVehicleTemplate VehicleTemplate { get; set; }
        public string VehiclePart { get; set; }
        public string Note { get; set; }
    }
}
