using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfBusinessType : BaseEntity
    {
        [Key]
        [Required]
        public string BusinessTypeCode { get; set; }
        public string BusinessTypeDesc { get; set; }
    }
}
