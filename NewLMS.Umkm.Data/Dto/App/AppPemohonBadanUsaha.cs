using System;
namespace NewLMS.Umkm.Data.Dto.Apps
{
    public class AppPemohonBadanUsaha
    {
        public Guid Id { get; set; }
        public string NamaCustomer { get; set; }
        public string NomorTelpon { get; set; }
        public string Alamat { get; set; }
        public int RFZipCodeId { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string KabupatenKota { get; set; }
        public string Propinsi { get; set; }
        public string NamaKontakDarurat { get; set; }
        public string NoTelpKontakDarurat { get; set; }
        public string AlamatKontakDarurat { get; set; }
        public int? RFZipCodeKontakDaruratId { get; set; }
        public string KelurahanKontakDarurat { get; set; }
        public string KecamatanKontakDarurat { get; set; }
        public string KabupatenKotaKontakDarurat { get; set; }
        public string PropinsiKontakDarurat { get; set; }

        
        public string NomorAktaPendirian { get; set; }
        public DateTime? TanggalAktaPendirian { get; set; }
        public string NomorPendaftaran { get; set; }
        public DateTime? TanggalSK { get; set; }
        public string PerubahanAktaTerakhir { get; set; }
        public DateTime? TanggalAkta { get; set; }
        public string NomorSIUP { get; set; }
        public DateTime? TanggalSIUP { get; set; }
        public string NomorTDP { get; set; }
        public DateTime? TanggalTDP { get; set; }
        public DateTime? TanggalJatuhTempoTDP { get; set; }
        public string NomorSKDP { get; set; }
        public DateTime? TanggalSKDP { get; set; }
        public DateTime? TanggalJatuhTempoSK { get; set; }
        public string NPWP { get; set; }

    }
}
