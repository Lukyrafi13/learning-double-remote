using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class DebtorCouple
    {
        [Key]
        [ForeignKey(nameof(Debtor))]
        [Required]
        public Guid Id { get; set; }

        [MaxLength(16)]
        public string NoIdentity { get; set; }
        public string Fullname { get; set; }

        public string? NPWP { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Neighborhoods { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public bool? IsAddressSameAsDebtor { get; set; }

        [ForeignKey(nameof(RfZipCode))]
        public int? ZipCodeId { get; set; }

        [ForeignKey(nameof(RfJob))]
        public string? JobCode { get; set; }

        public virtual RfZipCode RfZipCode { get; set; }
        public virtual RfJob RfJob { get; set; }
        public virtual RfMarital RfMarital { get; set; }

        public virtual Debtor Debtor { get; set; }
    }
}

