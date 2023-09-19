using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.AppraisalWorkPapers
{
    public class ApprLiquidationLandBuildingResponse
    {
        public List<ApprLiquidationResponse> LandLiquidationValue { get; set; }
        public List<ApprLiquidationResponse> BuildingLiquidationValue { get; set; }
    }
}
