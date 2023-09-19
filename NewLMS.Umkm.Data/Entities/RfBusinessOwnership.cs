using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfBusinessOwnership : BaseEntity
    {
        [Key]
        [Required]
        public string BusinessOwnershipCode { get; set; }
        public string BusinessOwnershipDesc { get; set; }
    }
}
