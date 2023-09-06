using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfCondition
{
    public class RfConditionResponse : BaseResponse
    {
        public string ConditionCode { get; set; }
        public string ConditionDesc { get; set; }
        public string ConditionCategory { get; set; }
        public bool? Active { get; set; }
    }

    public class RfConditionSimpleResponse
    {
        public string ConditionCode { get; set; }
        public string ConditionDesc { get; set; }
    }
}
