using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.AppraisalVehicle
{
    public class ApprVehicleNoteResponse
    {
        public Guid VehicleNoteGuid { get; set; }
        public Guid ApprVehicleTemplateGuid { get; set; }
        public string VehiclePart { get; set; }
        public string Note { get; set; }
    }
}
