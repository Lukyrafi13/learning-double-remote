using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfDecisionMakers
{
    public class RfDecisionMakerResponse : BaseResponse
    {
        public string DecisionMakerCode { get; set; }
        public string DecisionMakerDescription { get; set; }
    }

    public class RfDecisionMakerSimpleResponse
    {
        public string DecisionMakerCode { get; set; }
        public string DecisionMakerDescription { get; set; }
    }
}
