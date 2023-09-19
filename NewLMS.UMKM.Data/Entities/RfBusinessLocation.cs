using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfBusinessLocation : BaseEntity
    {
        [Key]
        [Required]
        public string BusinessLocationCode { get; set; }
        public string BusinessLocationDesc { get; set; }
    }
}
