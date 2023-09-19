using NewLMS.Umkm.Data.Dto.RfDecisionLetter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfScPosition
{
    public class RfScPositionResponse : BaseResponse
    {
        public string ScPositionCode { get; set; }
        public string ScPositionDesc { get; set; }
        public string SKCode { get; set; }
        public RfDecisionLetterResponse RfDecisionLetter { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }

    public class RfScPositionSimpleResponse
    {
        public string ScPositionCode { get; set; }
        public string ScPositionDesc { get; set; }
    }
}
