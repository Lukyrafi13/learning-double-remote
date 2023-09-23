using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfLinkAge : BaseEntity
    {
        [Key]
        [Required]
        public string LinkAgeCode { get; set; }
        public string LinkAgeDesc { get; set; }
    }
}
