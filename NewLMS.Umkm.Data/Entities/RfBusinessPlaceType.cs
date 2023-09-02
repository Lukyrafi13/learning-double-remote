using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfBusinessPlaceType : BaseEntity
    {
        [Key]
        [Required]
        public string BusinessPlaceTypeCode { get; set; }
        public string BusinessPlaceTypeDesc { get; set; }
    }
}
