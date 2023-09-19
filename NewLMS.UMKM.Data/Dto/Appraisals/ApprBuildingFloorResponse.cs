using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.Appraisals
{
    public class ApprBuildingFloorResponse
    {
        public Guid ApprBuildingTemplateGuid { get; set; }
        public List<ApprBuildingFloorEntityResponse> Floors { get; set; }
        public double? TotalBuildingArea { get; set; }
    }
}
