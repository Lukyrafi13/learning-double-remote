using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.AppraisalWorkPapers
{
    public class ApprVehicleSummaryRequest
    {
        public List<ApprVehicleRequest> BaseData { get; set; }
        public decimal? CurrShopValue { get; set; }
        public double? PctLiquidationValue { get; set; }
        public decimal? LiquidationValue { get; set; }
    }
}
