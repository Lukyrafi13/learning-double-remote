using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.Appraisals
{
    public class ApprBuildingFloorDetailPostRequest
    {
        public Guid ApprBuildingFloorGuid { get; set; }
        public string Description { get; set; }
        public string RoomName { get; set; }
        public int? Area { get; set; }
    }
}
