using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfPlacementCountry : BaseEntity
    {
        [Key]
        [Required]
        public string PlacementCountryCode { get; set; }
        public string PlacementCountryDesc { get; set; }
        public double? Kurs { get; set; }
        public bool? ShowKUR { get; set; }
        public string CoreCode { get; set; }
        public bool? Active { get; set; }
    }
}
