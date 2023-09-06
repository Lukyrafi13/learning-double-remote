using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfInstalmentType : BaseEntity
    {
        [Key]
        [Required]
        public Guid InstalmentTypeId { get; set; }
        public string InstalmentTypeDesc { get; set; }
    }
}
