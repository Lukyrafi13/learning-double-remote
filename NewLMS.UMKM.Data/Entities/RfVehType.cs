using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfVehType : BaseEntity
    {
        [Key]
        [Required]
        public string VehCode { get; set; }
        public string VehDesc { get; set; }
        public int CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
