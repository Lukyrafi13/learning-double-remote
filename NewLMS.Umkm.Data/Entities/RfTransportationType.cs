using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfTransportationType : BaseEntity
    {
        [Key]
        [Required]
        public string TransportationTypeCode { get; set; }
        public string TransportationTypeDesc { get; set; }
    }
}
