using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.AppraisalWorkPapers
{
    public class ApprLiquidationPostRequest
    {
        public string LiquidationOption { get; set; }
        public double? LiquidationScore { get; set; }
    }
}
