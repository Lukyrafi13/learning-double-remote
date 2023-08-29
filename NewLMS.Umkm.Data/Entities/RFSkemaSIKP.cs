using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFSkemaSIKP : BaseEntity
    {
        public Guid Id { get; set; }
        public string SkemaCode { get; set; }
        public string SkemaDesc { get; set; }
        public string SkemaParentCode { get; set; }
        public string SkemaParentDesc { get; set; }
        public bool? Active { get; set; }
    }
}
