using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfGender : BaseEntity
    {
        [Key]
        [Required]
        public string GenderCode { get; set; }
        public string GenderDesc { get; set; }
        public string GenderCodeSIKP { get; set; }
        public string GenderDescSIKP { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
