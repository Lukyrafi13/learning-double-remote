using System.ComponentModel.DataAnnotations;
using NewLMS.Umkm.Data;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfBank : BaseEntity
    {
        [Key]
        [Required]
        [MaxLength(5)]
        public string BankId { get; set; }

        public string BankName { get; set; }

        [MaxLength(10)]
        public string CoreCode { get; set; }

        public bool Active { get; set; }
    }
}
