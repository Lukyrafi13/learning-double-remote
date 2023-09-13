using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfMarital : BaseEntity
    {
        [Key]
        [Required]
        public string MaritalCode { get; set; }
        public string MaritalDesc { get; set; }
        public bool? WithSpouse { get; set; }
        public string MaritalCodeSKIP { get; set; }
        public string MaritalDescSKIP { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
