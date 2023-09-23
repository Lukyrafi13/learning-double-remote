using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfBusinessPlaceLocation : BaseEntity
    {
        [Key]
        [Required]
        public string RfBusinessPlaceLocationCode { get; set; }
        public string RfBusinessPlaceLocationDesc { get; set; }
    }
}
