using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfLinkAgeType : BaseEntity
    {
        [Key]
        [Required]
        public string LinkAgeTypeCode { get; set; }
        public string LinkAgeTypeDesc { get; set; }
    }
}
