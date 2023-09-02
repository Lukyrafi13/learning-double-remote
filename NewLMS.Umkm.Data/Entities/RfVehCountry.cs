using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfVehCountry : BaseEntity
    {
        [Key]
        [Required]
        public string VehCountryCode { get; set; }
        public string VehCountryDesc { get; set; }
        public string CoreCode { get; set; }
        public string Active { get; set; }
    }
}
