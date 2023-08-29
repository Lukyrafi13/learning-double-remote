using System;
namespace NewLMS.UMKM.Data.Dto.SIKPHistorys
{
    public class SIKPHistoryResponseDto
    {
        public Guid Id { get; set; }
        public string NoKTP { get; set; }
        public string KodeBank { get; set; }
        public int? SisaHariBook { get; set; }
        public double? Plafond { get; set; }
        public int? AkadDiizinkan { get; set; }
        public double? RateAkad { get; set; }
        public double? LimitAktif { get; set; }
        public string? RfSectorLBU3Code { get; set; }
        public string InquiryCode { get; set; }
        public RfSectorLBU3 SubSubSektorEkonomiLBU { get; set; }
    }
}
