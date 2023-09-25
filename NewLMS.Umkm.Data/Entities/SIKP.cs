using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewLMS.Umkm.Data.Enums;

namespace NewLMS.Umkm.Data.Entities
{
    public class SIKP : BaseEntity
    {
        [Key]
        [ForeignKey(nameof(LoanApplication))]
        [Required]
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; }
        public EnumSIKPStatus Status { get; set; }

        public virtual LoanApplication LoanApplication { get; set; }
        public virtual SIKPRequest SIKPRequest { get; set; }
        public virtual SIKPResponse SIKPResponse { get; set; }
    }
}

