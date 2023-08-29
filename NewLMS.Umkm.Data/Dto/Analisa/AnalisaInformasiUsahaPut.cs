using System;
namespace NewLMS.Umkm.Data.Dto.Analisas
{
    public class AnalisaInformasiUsahaPut
    {
        public Guid Id { get; set; }
        public bool? AlamatUsahaSamaDenganAplikasi { get; set; }
        public double? JarakLokasiUsahaDariCabang { get; set; }
        public string PerijinanYangDimiliki { get; set; }
        public string BuktiKepemilikanLainnya { get; set; }
        public string Nomor { get; set; }
        public bool? RACMemilikiUsaha { get; set; }
        public string NamaUsahaLain { get; set; }
        public int? LamaUsaha { get; set; }
        public int? LamaUsahaBidangIni { get; set; }
        public int? LamaMenempatiTempatUsaha { get; set; }
        public bool? MemilikiUsahaLain { get; set; }
        public bool? UsahaTidakTermasukJenisDihindari { get; set; }
        public string AktifitasUsaha { get; set; }
        public Guid? RFLokasiUsahaId { get; set; }
        public Guid? RFJenisTempatUsahaId { get; set; }
        public Guid? RFKelompokUsahaId { get; set; }
        public Guid? RFJenisUsahaId { get; set; }
        public Guid? RFLokasiTempatUsahaId { get; set; }
        public Guid? RFKepemilikanTUId { get; set; }
        public Guid? RFBuktiKepemilikanId { get; set; }
        public Guid? RFAspekPemasaranId { get; set; }
        public Guid? RFJumlahPegawaiTetapId { get; set; }
        public Guid? RFJumlahPegawaiHarianId { get; set; }
    }
}
