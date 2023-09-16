using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.AppraisalWorkPapers
{
    public class ApprLiquidationResponse
    {
        public Guid LiquidationGuid { get; set; }
        public SimpleResponse<string> LiquidationType { get; set; }
        public SimpleResponseWithScore<string> LiquidationItem { get; set; }
        public SimpleResponseWithScore<string> LiquidationOption { get; set; }
        public double? LiquidationScore { get; set; }
    }
}
