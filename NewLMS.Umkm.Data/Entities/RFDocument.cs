using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFDocument : BaseEntity
    {
        public Guid Id { get; set; }
        public string DocCode { get; set; }
        public string DocDesc { get; set; }
        public string GroupCode { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
        public int? Due { get; set; }
        public bool? ManDocNo { get; set; }
        public bool? ISTBO { get; set; }
        public bool? Mandatory { get; set; }
       
    }
}
