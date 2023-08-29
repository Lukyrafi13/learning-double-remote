using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class SIKPHistory : BaseEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("RFSectorLBU3Code")]
        public RFSectorLBU3 SubSubSektorEkonomiLBU { get; set; }
        public string NoKTP { get; set; }
        public string KodeBank { get; set; }
        public int? SisaHariBook { get; set; }
        public double? Plafond { get; set; }
        public string? RFSectorLBU3Code { get; set; }
        public string InquiryCode { get; set; }
    }
}
