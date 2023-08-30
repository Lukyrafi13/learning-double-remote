using System;
namespace NewLMS.UMKM.Data.Dto.Apps
{
    public class AppPemohonPerorangan
    {
        public Guid Id { get; set; }
        public string NamaCustomer { get; set; }
        public string TempatLahir { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string NomorKTP { get; set; }
        public DateTime? BerlakuSampaiDengan { get; set; }
        public bool SeumurHidup { get; set; }
        public string? NomorTelpon { get; set; }
        public Guid? KewarganegaraanId { get; set; }
        public Guid? RFEducationId { get; set; }
        public string NamaIbuKandung { get; set; }
        public int? JumlahTanggungan { get; set; }
        public string NPWP { get; set; }
        public Guid? RFMaritalId { get; set; }
        public Guid? RFJobId { get; set; }
        public string NomorAktaNikah { get; set; }
        public DateTime? TanggalAktaNikah { get; set; }
        public string PembuatAktaNikah { get; set; }
        public string Alamat { get; set; }
        public int RfZipCodeId { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string KabupatenKota { get; set; }
        public string Propinsi { get; set; }
        public int? LamaTinggal { get; set; }
        public Guid? RFHomestaId { get; set; }
        public string NamaLengkapPasangan { get; set; }
        public string NoKTPPasangan { get; set; }
        public string NPWPPasangan { get; set; }
        public Guid? RFJobPasanganId { get; set; }
        public string TempatLahirPasangan { get; set; }
        public DateTime? TanggalLahirPasangan { get; set; }
        public bool AlamatSamaDenganDebitur { get; set; }
        public string AlamatPasangan { get; set; }
        public int? RfZipCodePasanganId { get; set; }
        public string KelurahanPasangan { get; set; }
        public string KecamatanPasangan { get; set; }
        public string KabupatenKotaPasangan { get; set; }
        public string PropinsiPasangan { get; set; }
        public string NamaKontakDarurat { get; set; }
        public string NoTelpKontakDarurat { get; set; }
        public string NoKTPKontakDarurat { get; set; }
        public string AlamatKontakDarurat { get; set; }
        public int? RfZipCodeKontakDaruratId { get; set; }
        public string KelurahanKontakDarurat { get; set; }
        public string KecamatanKontakDarurat { get; set; }
        public string KabupatenKotaKontakDarurat { get; set; }
        public string PropinsiKontakDarurat { get; set; }

    }
}
