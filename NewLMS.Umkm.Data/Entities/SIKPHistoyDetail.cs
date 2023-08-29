using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class SIKPHistoryDetail : BaseEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("SIKPHistoryId")]
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
