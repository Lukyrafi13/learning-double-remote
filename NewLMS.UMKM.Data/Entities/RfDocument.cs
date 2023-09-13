using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfDocument : BaseEntity
    {
        [Key]
        [Required]
        public string DocumentCode { get; set; }
        public string DocumentDesc { get; set; }
        public string GroupCode { get; set; }
        public int? Due { get; set; }
        public bool? ManDocNo { get; set; }
        public bool? ISTBO { get; set; }
        public bool? Mandatory { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
