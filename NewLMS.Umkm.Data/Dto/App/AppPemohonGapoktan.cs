using System;
namespace NewLMS.Umkm.Data.Dto.Apps
{
    public class AppPemohonGapoktan
    {
        public Guid Id { get; set; }
        public string NamaCustomer { get; set; }
        public string? NomorTelpon { get; set; }
        public int? JumlahAnggota { get; set; }
        public string PemilikBarang { get; set; }
        public DateTime? TanggalAktaPendirian { get; set; }
        public string NPWP { get; set; }
        public string Alamat { get; set; }
        public int RFZipCodeId { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string KabupatenKota { get; set; }
        public string Propinsi { get; set; }

        // Ketua
        public string NamaLengkapKetua { get; set; }
        public string TempatLahirKetua { get; set; }
        public DateTime? TanggalLahirKetua { get; set; }
        public string JabatanKetua { get; set; }
        public string NoKTPKetua { get; set; }
        public DateTime? MasaBerlakuKTPKetua { get; set; }
        public string NPWPKetua { get; set; }
        public string NoTelpKetua { get; set; }
        public string AlamatKetua { get; set; }
        public string KelurahanKetua { get; set; }
        public string KecamatanKetua { get; set; }
        public string KabupatenKotaKetua { get; set; }
        public string PropinsiKetua { get; set; }

        // Bendahara
        public string NamaLengkapBendahara { get; set; }
        public string TempatLahirBendahara { get; set; }
        public DateTime? TanggalLahirBendahara { get; set; }
        public string JabatanBendahara { get; set; }
        public string NoKTPBendahara { get; set; }
        public DateTime? MasaBerlakuKTPBendahara { get; set; }
        public string NPWPBendahara { get; set; }
        public string NoTelpBendahara { get; set; }
        public string AlamatBendahara { get; set; }
        public string KelurahanBendahara { get; set; }
        public string KecamatanBendahara { get; set; }
        public string KabupatenKotaBendahara { get; set; }
        public string PropinsiBendahara { get; set; }

        // Informasi Usaha
        public int? LamaUsaha { get; set; }
        public string JenisKomoditas { get; set; }

        public Guid? RFMaritalKetuaId { get; set; }
        public Guid? RFEducationKetuaId { get; set; }
        public int? RFZipCodeKetuaId { get; set; }
        public Guid? RFMaritalBendaharaId { get; set; }
        public Guid? RFEducationBendaharaId { get; set; }
        public int? RFZipCodeBendaharaId { get; set; }
        
    }
}
