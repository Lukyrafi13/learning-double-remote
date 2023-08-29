using System;
namespace NewLMS.Umkm.Data.Dto.Apps
{
    public class AppGudang
    {
        public Guid Id { get; set; }
        public string NoResi { get; set; }
        public string NoSeriResiGudang { get; set; }
        public string NamaPemilikResi { get; set; }
        public DateTime? TglTerbitResi { get; set; }
        public DateTime? TglJatuhTempoResiGudang { get; set; }
        public string JenisBarang { get; set; }
        public double? JumlahBarangKg { get; set; }
        public double? NilaiBarang { get; set; }
        public string LokasiGudangPenyimpanan { get; set; }
        public string NamaLengkapPengelola { get; set; }
        public string NoKTPPengelola { get; set; }
        public DateTime? TglLahirPengelola { get; set; }

    }
}
