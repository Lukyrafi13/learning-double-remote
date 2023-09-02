using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfOwnerCategory : BaseEntity
    {
        [Key]
        [Required]
        public string OwnerCategoryCode { get; set; }
        public string OwnerCategoryDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
