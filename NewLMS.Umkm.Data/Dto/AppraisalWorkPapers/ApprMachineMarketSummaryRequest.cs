using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.AppraisalWorkPapers
{
    public class ApprMachineMarketSummaryRequest
    {
        public List<ApprMachineMarketWorkPaperPostRequest> BaseData { get; set; }
        public decimal? CurrMarketValue { get; set; }
        public double? PctLiquidationValue { get; set; }
        public decimal? LiquidationValue { get; set; }
    }
}
