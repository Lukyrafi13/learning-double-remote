using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfBusinessFieldKUR : BaseEntity
    {
        [Key]
        [Required]
        public string BusinessFieldKURCode { get; set; }
        public string BusinessFieldKURDesc { get; set; }
    }
}
