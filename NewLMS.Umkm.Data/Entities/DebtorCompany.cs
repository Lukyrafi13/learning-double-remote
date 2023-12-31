using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Entities
{
    public class DebtorCompany : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Neighborhoods { get; set; }


        [ForeignKey(nameof(RfZipCode))]
        public int? ZipCodeId { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual DebtorCompanyLegal DebtorCompanyLegal { get; set; }
        public virtual RfZipCode RfZipCode { get; set; }
    }
}
