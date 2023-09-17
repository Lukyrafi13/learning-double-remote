using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class ApprReceivableVerification : BaseEntity
    {
        [Key]
        [Required]
        public Guid ApprReceivableVerificationGuid { get; set; }

        [ForeignKey(nameof(LoanApplicationAppraisal))]
        public Guid AppraisalGuid { get; set; }
        public virtual LoanApplicationAppraisal LoanApplicationAppraisal { get; set; }

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
