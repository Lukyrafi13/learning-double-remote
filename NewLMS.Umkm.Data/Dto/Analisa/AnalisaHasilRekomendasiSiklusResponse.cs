using System;

namespace NewLMS.Umkm.Data.Dto.Analisas
{
    public class AnalisaHasilRekomendasiSiklusResponse : AnalisaHasilRekomendasiSiklusPut
    {
        public RFKepemilikanUsaha KepemilikanTempatUsaha { get; set; }
        public RFLamaUsahaLain LamaMenempatiLokasi { get; set; }

        public double? TotalPendapatan { get; set; }
        public double? TotalBiaya { get; set; }
        public double? TotalBiayaOperasional { get; set; }
        public double? TotalBiayaTetap { get; set; }
        public double? TotalBiayaVariabel { get; set; }
        public double? SaldoAkhir { get; set; }
        public double? TotalAngsuran { get; set; }
        public double? RekomendasiAngsuran { get; set; }
        public double? RCR { get; set; }
        public double? BCR { get; set; }
        public double? BEP { get; set; }
        public double? DSR { get; set; }
    }
}
