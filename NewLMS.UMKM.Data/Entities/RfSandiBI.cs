using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfSandiBI : BaseEntity
    {
        [Key]
        [Required]
        [MaxLength(10)]
        public string RfSandiBIId { get; set; }

        [Required]
        [MaxLength(3)]
        [ForeignKey(nameof(RfSandiBIGroup))]
        public string BIGroup { get; set; }

        [MaxLength(5)]
        public string BIType { get; set; }

        [MaxLength(10)]
        public string BICode { get; set; }

        public string BIDesc { get; set; }

        [MaxLength(10)]
        public string CoreCode { get; set; }

        public bool Active { get; set; }

        public string CategoryCode { get; set; }

        public string LBU2Code { get; set; }

        public virtual RfSandiBIGroup RfSandiBIGroup { get; set; }
    }
}
