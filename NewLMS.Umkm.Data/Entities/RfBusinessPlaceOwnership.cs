using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfBusinessPlaceOwnership : BaseEntity
    {
        [Key]
        [Required]
        public string BusinessPlaceOwnCode { get; set; }
        public string BusinessPlaceOwnDesc { get; set; }

        [ForeignKey(nameof(RfBusinessPlaceLocation))]
        public string BusinessPlaceLocationCode { get; set; }

        public virtual RfBusinessPlaceLocation RfBusinessPlaceLocation { get; set; }
    }
}
