using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFBranchInsComp : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public string BranchId { get; set; }
        public string CompId { get; set; }
        public string TPLCode { get; set; }
        public bool? Active { get; set; }
    }
}