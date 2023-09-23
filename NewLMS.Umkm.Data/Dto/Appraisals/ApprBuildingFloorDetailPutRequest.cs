using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.Appraisals
{
    public class ApprBuildingFloorDetailPutRequest
    {
        public Guid BuildingFloorDetailGuid { get; set; }
        public string Description { get; set; }
        public string RoomName { get; set; }
        public string Area { get; set; }
    }
}
