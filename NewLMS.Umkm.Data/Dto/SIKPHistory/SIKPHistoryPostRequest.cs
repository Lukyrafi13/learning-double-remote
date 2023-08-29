using System;
using System.Collections.Generic;

namespace NewLMS.UMKM.Data.Dto.SIKPHistorys
{
    public class SIKPHistoryDetailDTO {
        public string KodeBank { get; set; }
        public int? SisaHari { get; set; }
        public string Skema { get; set; }
        public int? JumlahAkad { get; set; }
        public int? MaxJumlahAkad { get; set; }
        public double? RateAkad { get; set; }
        public double? LimitAktifDefault { get; set; }
        public double? LimitAktif { get; set; }
        public double? TotalLimitDefault { get; set; }
        public double? TotalLimit { get; set; }
        public Guid? SIKPHistoryId { get; set; }
    }

    public class SIKPHistoryPostRequestDto
    {
        public string NoKTP { get; set; }
        public string KodeBank { get; set; }
        public int? SisaHariBook { get; set; }
        public double? Plafond { get; set; }
        public string? RfSectorLBU3Code { get; set; }
        public string InquiryCode { get; set; }

        public List<SIKPHistoryDetailDTO> Details { get; set; }
    }
}
