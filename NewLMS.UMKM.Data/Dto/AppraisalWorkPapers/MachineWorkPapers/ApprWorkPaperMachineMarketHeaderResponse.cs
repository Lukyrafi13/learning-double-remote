using NewLMS.Umkm.Data.Dto.Appraisals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.AppraisalWorkPapers.MachineWorkPapers
{
    public class ApprWorkPaperMachineMarketHeaderResponse
    {
        public List<ApprMachineMarketWorkPaperResponse> MarketData { get; set; }
        public decimal? CurrMarketValue { get; set; }
        public List<ApprLiquidationResponse> LiquidationData { get; set; }
        public double? PctLiquidationValue { get; set; }
    }
}
