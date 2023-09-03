using NewLMS.UMKM.Data.Dto.RfDecisionLetterType;
using NewLMS.UMKM.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfDecisionLetter
{
    public class RfDecisionLetterResponse : BaseResponse
    {
        public string DecisionLeterCode { get; set; }
        public string DecisionLeterDesc { get; set; }
        public RfDecisionLetterTypeSimpleResponse RfDecisionLeterType { get; set; }
        public string DecisionLeterNumber { get; set; }
        public string DecisionLeterBy { get; set; }
        public string DecisionLeterMatter { get; set; }
        public DateTime? DecisionLeterDate { get; set; }
        public string DecisionLeterClausal { get; set; }
        public DateTime? DecisionLeterExpDate { get; set; }
        public double? Limit { get; set; }
    }

    public class RfDecisionLetterSimpleResponse
    {
        public string DecisionLeterCode { get; set; }
        public string DecisionLeterDesc { get; set; }
    }
}
