using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfSkemaSIKP : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string SkemaCode { get; set; }
        public string SkemaDesc { get; set; }
        public string SkemaParentCode { get; set; }
        public string SkemaParentDesc { get; set; }
        public bool? Active { get; set; }
    }
}
