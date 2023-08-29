using System;
namespace NewLMS.Umkm.Data.Dto.Analisas
{
    public class AnalisaHubunganBankResponse : AnalisaHubunganBankPut
    {
        public double? TotalPlafon { get; set; }
        public double? TotalOutstanding { get; set; }
        public double? PlafonModalKerja { get; set; }
        public double? OutstandingModalKerja { get; set; }
        public double? PlafonInvestasi { get; set; }
        public double? OutstandingInvestasi { get; set; }
        public double? PlafonKonsumtif { get; set; }
        public double? OutstandingKonsumtif { get; set; }
    }
}
