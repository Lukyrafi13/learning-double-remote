using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RfInstituteCode : BaseEntity
    {
        [Key]
        [Required]
        public string ServiceCode { get; set; }
        public string Partner { get; set; }
        public string EconomySector { get; set; }
        public string Cultivation { get; set; }
        public bool Active { get; set; }

    }
}
