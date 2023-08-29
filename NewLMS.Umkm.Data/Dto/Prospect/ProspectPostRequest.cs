using System;
namespace NewLMS.Umkm.Data.Dto.Prospects
{
    public class ProspectPostRequestDto
    {
        public string NamaCustomer { get; set; }
        public string StatusPerusahaan { get; set; }
        public string NomorTelpon { get; set; }
        public string Alamat { get; set; }
        public int KodePosId { get; set; }
        public string Kelurahan { get; set; }
        public bool AlamatSesuaiKTP { get; set; }
        public string AlamatTempat { get; set; }
        public int KodePosTempatId { get; set; }
        public string KelurahanTempat { get; set; }
        public Guid RFJenisPermohonanId { get; set; }
        public string Alasan { get; set; }
        public double PerkiraanPengajuan { get; set; }
        public DateTime TanggalProspect { get; set; }
        public Guid RFProductId { get; set; }
        public Guid RFOwnerCategoryId { get; set; }
        public Guid? RFGenderId { get; set; }
        public Guid RFStatusId { get; set; }
        public string RFSectorLBU1Code { get; set; }
        public string RFSectorLBU2Code { get; set; }
        public string RFSectorLBU3Code { get; set; }
        public Guid RFKategoriId { get; set; }
        public Guid? RFKodeDinasId { get; set; }
        public string NamaAO { get; set; }
        public string KodeCabang { get; set; }
        public string NamaCabang { get; set; }
        public string NomorKTP { get; set; }
        public string TempatLahir { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string NamaUsaha { get; set; }
        public string AlamatUsaha { get; set; }
        public string AlamatLengkapUsaha { get; set; }
        public string KelurahanUsaha { get; set; }
        public string KecamatanUsaha { get; set; }
        public string KabupatenKotaUsaha { get; set; }
        public string PropinsiUsaha { get; set; }
        public int? RFZipCodeUsahaId { get; set; }
        public Guid? RFKelompokUsahaId { get; set; }
        public Guid? RFJenisUsahaId { get; set; }
        public string JenisUsahaLain { get; set; }
    }
}
