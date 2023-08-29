using System;
namespace NewLMS.Umkm.Data.Dto.SIKPHistoryDetails
{
    public class SIKPHistoryDetailResponseDto
    {
        public Guid Id { get; set; }
        public SIKPHistory SIKPHistory { get; set; }
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
        public Guid SIKPHistoryId { get; set; }
    }
}
