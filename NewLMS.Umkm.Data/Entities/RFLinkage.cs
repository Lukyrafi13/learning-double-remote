using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFLinkage : BaseEntity
    {
        public Guid Id { get; set; }
        public string LinkCode { get; set; }
        public string LinkDesc { get; set; }
        public string SIKPCode { get; set; }
        public bool? Active { get; set; }
    }
}
