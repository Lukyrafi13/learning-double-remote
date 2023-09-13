using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfApplicationType : BaseEntity
    {
        [Key]
        [Required]
        public string ApplicationTypeId { get; set; }
        public string ApplicationTypeDesc { get; set; }
    }
}
