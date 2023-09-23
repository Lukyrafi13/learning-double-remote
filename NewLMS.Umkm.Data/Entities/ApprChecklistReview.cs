using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class ApprChecklistReview : BaseEntity
    {
        [Key]
        [Required]
        public Guid ApprChecklistReviewGuid { get; set; }

        [ForeignKey(nameof(LoanApplicationAppraisal))]
        public Guid AppraisalGuid { get; set; }
        public virtual LoanApplicationAppraisal LoanApplicationAppraisal { get; set; }
        public int Sequence { get; set; }
        public string Description { get; set; }
        public string Yesno { get; set; }
        public string Remarks { get; set; }
    }
}
