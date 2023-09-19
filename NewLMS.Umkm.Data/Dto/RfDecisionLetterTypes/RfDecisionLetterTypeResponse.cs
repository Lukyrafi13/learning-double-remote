using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfDecisionLetterType
{
    public class RfDecisionLetterTypeResponse : BaseResponse
    {
        public string DecisionLeterTypeCode { get; set; }
        public string DecisionLeterTypeDesc { get; set; }
    }

    public class RfDecisionLetterTypeSimpleResponse
    {
        public string DecisionLeterTypeCode { get; set; }
        public string DecisionLeterTypeDesc { get; set; }
    }
}
