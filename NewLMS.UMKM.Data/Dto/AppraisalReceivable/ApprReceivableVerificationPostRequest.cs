using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.AppraisalReceivable
{
    public class ApprReceivableVerificationPostRequest
    {
        public Guid AppraisalGuid { get; set; }
        public string ObjectType { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string Document { get; set; }
        public string DocumentNo { get; set; }
        public string Method { get; set; }
        public string Population { get; set; }
        public string VerificationResult { get; set; }
        public string Remarks { get; set; }
        public Boolean ObjectStatus { get; set; }
        public string VerificationBy { get; set; }
        public string CollateralOwner { get; set; }
    }
}
