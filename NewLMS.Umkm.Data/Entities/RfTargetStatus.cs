using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfTargetStatus : BaseEntity
    {
        [Key]
        [Required]
        public string TargetStatusCode { get; set; }
        public string TargetStatusDesc { get; set; }
        public bool Active { get; set; }
    }
}
