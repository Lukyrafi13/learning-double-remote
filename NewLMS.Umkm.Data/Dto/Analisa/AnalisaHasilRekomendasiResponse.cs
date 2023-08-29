using System;

namespace NewLMS.Umkm.Data.Dto.Analisas
{
    public class AnalisaHasilRekomendasiResponse : AnalisaHasilRekomendasiPut
    {
        public double? PerputaranPiutangDagang { get; set; }
        public double? PerputaranPersediaanBarang { get; set; }
        public double? PerputaranHutangDagang { get; set; }
        public double? PerputaranModalKerja { get; set; }
        public double? KebutuhanModalKerjaNormal { get; set; }
        public double? MaxModalKerja { get; set; }
    }
}
