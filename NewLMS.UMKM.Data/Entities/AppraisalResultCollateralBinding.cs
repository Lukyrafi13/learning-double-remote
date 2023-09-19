using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class AppraisalResultCollateralBinding : BaseEntity
    {
        [Key]
        [Required]
        public Guid CollateralBindingGuid { get; set; }
        [ForeignKey(nameof(AppraisalResults))]
        public Guid AppraisalResultGuid { get; set; }
        [ForeignKey(nameof(RFCollaterals))]
        public string CollateralCode { get; set; }
        [ForeignKey(nameof(BindingTypeFK))]
        public Guid? BindingTypeGuid { get; set; }
        [ForeignKey(nameof(LoanFacilities))]
        public Guid? FacilityGuid { get; set; }
        [ForeignKey(nameof(BindingFK))]
        public Guid? BindingGuid { get; set; }
        public decimal? BindingValue { get; set; }
        public int? BindingRank { get; set; }

        public virtual AppraisalResults AppraisalResults { get; set; }
        public virtual LoanApplicationFacility LoanFacilities { get; set; }
        public virtual RfCollateralBC RFCollaterals { get; set; }
        public virtual Parameters BindingTypeFK { get; set; }
        public virtual Parameters BindingFK { get; set; }
    }
}
