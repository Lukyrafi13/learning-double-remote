using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfEducation : BaseEntity
    {
        [Key]
        [Required]
        public string EducationCode { get; set; }
        public string EducationDesc { get; set; }
        public string EducationCodeSIKP { get; set; }
        public string EducationDescSIKP { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
