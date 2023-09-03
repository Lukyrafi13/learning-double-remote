using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RfCategory : BaseEntity
    {
        [Key]
        [Required]
        public string CategoryCode { get; set; }
        public string CategoryDesc { get; set; }
        public bool Active { get; set; }

    }
}