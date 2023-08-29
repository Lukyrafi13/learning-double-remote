using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFSiklusUsaha : BaseEntity
    {
        public Guid Id { get; set; }
        public string SiklusCode { get; set; }
        public string SiklusDesc { get; set; }
        public string CoreCode { get; set; }
        public bool? IsResiGudang { get; set; }
        public int? MCount { get; set; }
        public bool Active { get; set; }
    }
}
