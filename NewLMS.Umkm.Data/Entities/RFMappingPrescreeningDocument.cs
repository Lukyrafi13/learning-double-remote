using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFMappingPrescreeningDocument : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public string TypeCode { get; set; }
        public string ProductId { get; set; }
        public string OwnCode { get; set; }
        public string DocCode { get; set; }
        public RFDocument RFDocument { get; set; }
    }
}
