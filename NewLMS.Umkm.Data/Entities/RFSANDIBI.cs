using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFSANDIBI : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }
        public string BI_TYPE { get; set; }
        public string BI_GROUP { get; set; }
        public string BI_CODE { get; set; }
        public string BI_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool? ACTIVE { get; set; }
        public string KATEGORI_CODE { get; set; }
        public string LBU2_CODE { get; set; }
    }
}
