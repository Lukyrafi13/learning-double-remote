using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data.Entities
{
    public class SIKP : BaseEntity
    {
        [Key]
        [ForeignKey(nameof(LoanApplication))]
        [Required]
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; }

        public virtual LoanApplication LoanApplication { get; set; }
        public virtual SIKPRequest SIKPRequest { get; set; }
        public virtual SIKPResponse SIKPResponse { get; set; }
    }
}

