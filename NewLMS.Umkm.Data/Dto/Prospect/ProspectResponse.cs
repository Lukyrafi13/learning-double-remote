using System;
namespace NewLMS.UMKM.Data.Dto.Prospects
{
    public class ProspectResponseDto
    {
        public Guid Id { get; set; }
        public string ProspectId { get; set; }

        public RfProduct JenisProduk { get; set; }
        public RfOwnerCategory TipeDebitur { get; set; }
        public string NamaCustomer { get; set; }
        public string NamaDepanCustomer { get; set; }
        public string NamaTengahCustomer { get; set; }
        public string NamaBelakangCustomer { get; set; }
        public RfGender JenisKelamin { get; set; }
        public string StatusPerusahaan { get; set; }
        public string NomorTelpon { get; set; }
        public string NomorKTP { get; set; }
        public string TempatLahir { get; set; }
        public DateTime? TanggalLahir { get; set; }

        // Alamat Debitor
        public string Alamat { get; set; }
        public RfZipCode KodePos { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string KabupatenKota { get; set; }
        public string Propinsi { get; set; }

        // Alamat Tempat
        public bool AlamatSesuaiKTP { get; set; }
        public string AlamatTempat { get; set; }
        public RfZipCode KodePosTempat { get; set; }
        public string KelurahanTempat { get; set; }
        public string KecamatanTempat { get; set; }
        public string KabupatenKotaTempat { get; set; }
        public string PropinsiTempat { get; set; }

        // Target
        public string NamaAO { get; set; }
        public string NamaCabang { get; set; }
        public string KodeCabang { get; set; }
        public RfAppType JenisPermohonanKredit { get; set; }
        public RfTargetStatus Status { get; set; }
        public RfSectorLBU1 SektorEkonomi { get; set; }
        public RfSectorLBU2 SubSektorEkonomi { get; set; }
        public RfSectorLBU3 SubSubSektorEkonomi { get; set; }
        public string Alasan { get; set; }
        public double PerkiraanPengajuan { get; set; }
        public DateTime TanggalProspect { get; set; }

        // Data Usaha - Perorangan
        public string NamaUsaha { get; set; }
        public string AlamatUsaha { get; set; }
        public string AlamatLengkapUsaha { get; set; }
        public RfZipCode KodePosUsaha { get; set; }
        public string KelurahanUsaha { get; set; }
        public string KecamatanUsaha { get; set; }
        public string KabupatenKotaUsaha { get; set; }
        public string PropinsiUsaha { get; set; }

        // Data Usaha - Badan Usaha
        public RfCompanyGroup KelompokBidangUsaha { get; set; } 
        public RfCompanyType JenisUsaha { get; set; }
        public string JenisUsahaLain { get; set; }

        // etc
        public string SumberData { get; set; }
        public RfCategory Kategori { get; set; } 
        public RFKodeDinas KodeDinas { get; set; }
        public RFStages Stage { get; set; }

        public int Age { get; set; }

        // Foreign keys
        
        public Guid RfProductId { get; set; }
        public Guid RfOwnerCategoryId { get; set; }
        public Guid? RfGenderId { get; set; }
        public Guid RFStatusId { get; set; }
        public Guid RfAppTypeId { get; set; }
        public string RfSectorLBU1Code { get; set; }
        public string RfSectorLBU2Code { get; set; }
        public string RfSectorLBU3Code { get; set; }
        public int? RfZipCodeId { get; set; }
        public Guid RfCategoryId { get; set; }
        public Guid? RFKodeDinasId { get; set; }
        public int? RFStagesId { get; set; }
        public int? RfZipCodeUsahaId { get; set; }
        public Guid? RfCompanyGroupId { get; set; }
        public Guid? RfCompanyTypeId { get; set; }
        public int? RfZipCodeTempatId { get; set; }
    }
}
