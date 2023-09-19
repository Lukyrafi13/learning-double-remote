using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfVehMaker : BaseEntity
    {
        [Key]
        [Required]
        public string VehMakerCode { get; set; }
        public string VehmakerDesc { get; set; }

        [ForeignKey(nameof(RfVehType))]
        public string VehCode { get; set; }
        
        [ForeignKey(nameof(RfVehCountry))]
        public string VehCountryCode { get; set; }

        [ForeignKey(nameof(RfCollateralBC))]
        public string CollateralCode { get; set; }

        public string CoreCode { get; set; }
        public bool Active { get; set; }

        public virtual RfVehType RfVehType { get; set; }
        public virtual RfVehCountry RfVehCountry { get; set; }
        public virtual RfCollateralBC RfCollateralBC { get; set; }
    }
}
