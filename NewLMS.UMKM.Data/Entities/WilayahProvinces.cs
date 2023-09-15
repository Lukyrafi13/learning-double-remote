using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewLMS.UMKM.Data.Entities
{
    public class WilayahProvinces
    {
        [Key]
        [Required]
        [Column(Order = 0)]
        public string Code { get; set; }
        [Column(Order = 1)]
        public string Name { get; set; }
        [Column(Order = 2)]
        public bool IsActive { get; set; }
    }
}
