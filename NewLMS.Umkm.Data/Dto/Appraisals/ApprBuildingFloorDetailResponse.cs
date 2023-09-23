using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.Appraisals
{
    public class ApprBuildingFloorDetailResponse
    {
        public Guid BuildingFloorDetailGuid { get; set; }
        public Guid ApprBuildingFloorGuid { get; set; }
        public string Description { get; set; }
        public string RoomName { get; set; }
        public double? RoomArea { get; set; }
    }
}
