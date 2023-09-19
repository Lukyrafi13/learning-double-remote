using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class WilayahDistricts
    {
        [Key]
        [Required]
        [Column(Order = 0)]
        public string Code { get; set; }
        [ForeignKey(nameof(WilayahRegencies))]
        [Column(Order = 1)]
        public string ParentCode { get; set; }
        [Column(Order = 2)]
        public string Name { get; set; }
        [Column(Order = 3)]
        public bool IsActive { get; set; }
        public virtual WilayahRegencies WilayahRegencies { get; set; }
    }
}
