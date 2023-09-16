using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.Appraisals
{
    public class ApprBuildingFloorEntityResponse
    {
        public Guid BuildingFloorGuid { get; set; }
        public string Description { get; set; }
        public int? RoomNumber { get; set; }
        public double? Area { get; set; }
    }
}
