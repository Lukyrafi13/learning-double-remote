using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfVehModel : BaseEntity
    {
        [Key]
        [Required]
        public string VehModelCode { get; set; }
        public string VehModelDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
