using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class AppraisalResults : BaseEntity
    {
        [Key]
        [Required]
        [Column(Order = 0)]
        public Guid AppraisalResultGuid { get; set; }

        [ForeignKey(nameof(LoanApplications))]
        [Column(Order = 1)]
        public Guid LoanApplicationGuid { get; set; }
        [Column(Order = 1)]
        public string Remark { get; set; }

        public virtual LoanApplication LoanApplications { get; set; }
        public virtual ICollection<AppraisalResultCollateralBinding> AppraisalResultCollateralBindings { get; set; }
    }
}
