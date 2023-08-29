using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class SIKPHistory : BaseEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("RfSectorLBU3Code")]
        public RfSectorLBU3 SubSubSektorEkonomiLBU { get; set; }
        public string NoKTP { get; set; }
        public string KodeBank { get; set; }
        public int? SisaHariBook { get; set; }
        public double? Plafond { get; set; }
        public string? RfSectorLBU3Code { get; set; }
        public string InquiryCode { get; set; }
    }
}
