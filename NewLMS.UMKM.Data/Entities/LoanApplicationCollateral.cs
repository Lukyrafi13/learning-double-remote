using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data.Entities
{
    public class LoanApplicationCollateral : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationId { get; set; }
        public string CollateralBCId { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DocumentReleaseDate { get; set; }
        public DateTime? DocumentExpireDate { get; set; }
        public string DocumentPublisher { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhoods { get; set; }

        [ForeignKey(nameof(RfZipCode))]
        public int ZipCodeId { get; set; }

        public virtual LoanApplication LoanApplication { get; set; }
        public virtual LoanApplicationCollateralOwner LoanApplicationCollateralOwner { get; set; }

        public virtual RfZipCode RfZipCode { get; set; }
    }
}
