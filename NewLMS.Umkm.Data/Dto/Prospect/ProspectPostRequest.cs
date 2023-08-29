using System;
namespace NewLMS.UMKM.Data.Dto.Prospects
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
        public Guid RfAppTypeId { get; set; }
        public string Alasan { get; set; }
        public double PerkiraanPengajuan { get; set; }
        public DateTime TanggalProspect { get; set; }
        public Guid RfProductId { get; set; }
        public Guid RfOwnerCategoryId { get; set; }
        public Guid? RfGenderId { get; set; }
        public Guid RFStatusId { get; set; }
        public string RfSectorLBU1Code { get; set; }
        public string RfSectorLBU2Code { get; set; }
        public string RfSectorLBU3Code { get; set; }
        public Guid RfCategoryId { get; set; }
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
        public int? RfZipCodeUsahaId { get; set; }
        public Guid? RfCompanyGroupId { get; set; }
        public Guid? RfCompanyTypeId { get; set; }
        public string JenisUsahaLain { get; set; }
    }
}
