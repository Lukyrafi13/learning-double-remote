using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.ChekingSIKPs
{
    public class ChekingSIKPChekRequest
    {
        public string NoIdentiry { get; set; }
        public double? PlanPlafond { get; set; }
        public string SectorLBU3Code { get; set; }
    }
}
