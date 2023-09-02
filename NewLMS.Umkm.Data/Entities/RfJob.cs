using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfJob : BaseEntity
    {
        [Key]
        [Required]
        public string JobCode { get; set; }
        public string JobDesc { get; set; }
        public string JobType { get; set; }
        public string JobSCRType { get; set; }
        public string JobCodeSIKP { get; set; }
        public string JobDescSIKP { get; set; }
        public bool? Sensitive { get; set; }
        public bool? Other { get; set; }
        [ForeignKey(nameof(RfProduct))]
        public string ProductId { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }


        public virtual RfProduct RfProduct { get; set; }
    }
}
