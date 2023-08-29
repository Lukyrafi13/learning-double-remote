using System;
namespace NewLMS.Umkm.Data.Dto.Prospects
{
    public class ProspectResponseDto
    {
        public Guid Id { get; set; }
        public string ProspectId { get; set; }

        public RFProduct JenisProduk { get; set; }
        public RFOwnerCategory TipeDebitur { get; set; }
        public string NamaCustomer { get; set; }
        public string NamaDepanCustomer { get; set; }
        public string NamaTengahCustomer { get; set; }
        public string NamaBelakangCustomer { get; set; }
        public RFGender JenisKelamin { get; set; }
        public string StatusPerusahaan { get; set; }
        public string NomorTelpon { get; set; }
        public string NomorKTP { get; set; }
        public string TempatLahir { get; set; }
        public DateTime? TanggalLahir { get; set; }

        // Alamat Debitor
        public string Alamat { get; set; }
        public RFZipCode KodePos { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string KabupatenKota { get; set; }
        public string Propinsi { get; set; }

        // Alamat Tempat
        public bool AlamatSesuaiKTP { get; set; }
        public string AlamatTempat { get; set; }
        public RFZipCode KodePosTempat { get; set; }
        public string KelurahanTempat { get; set; }
        public string KecamatanTempat { get; set; }
        public string KabupatenKotaTempat { get; set; }
        public string PropinsiTempat { get; set; }

        // Target
        public string NamaAO { get; set; }
        public string NamaCabang { get; set; }
        public string KodeCabang { get; set; }
        public RFJenisPermohonan JenisPermohonanKredit { get; set; }
        public RFStatusTarget Status { get; set; }
        public RFSectorLBU1 SektorEkonomi { get; set; }
        public RFSectorLBU2 SubSektorEkonomi { get; set; }
        public RFSectorLBU3 SubSubSektorEkonomi { get; set; }
        public string Alasan { get; set; }
        public double PerkiraanPengajuan { get; set; }
        public DateTime TanggalProspect { get; set; }

        // Data Usaha - Perorangan
        public string NamaUsaha { get; set; }
        public string AlamatUsaha { get; set; }
        public string AlamatLengkapUsaha { get; set; }
        public RFZipCode KodePosUsaha { get; set; }
        public string KelurahanUsaha { get; set; }
        public string KecamatanUsaha { get; set; }
        public string KabupatenKotaUsaha { get; set; }
        public string PropinsiUsaha { get; set; }

        // Data Usaha - Badan Usaha
        public RFKelompokUsaha KelompokBidangUsaha { get; set; } 
        public RFJenisUsaha JenisUsaha { get; set; }
        public string JenisUsahaLain { get; set; }

        // etc
        public string SumberData { get; set; }
        public RFKategori Kategori { get; set; } 
        public RFKodeDinas KodeDinas { get; set; }
        public RFStages Stage { get; set; }

        public int Age { get; set; }

        // Foreign keys
        
        public Guid RFProductId { get; set; }
        public Guid RFOwnerCategoryId { get; set; }
        public Guid? RFGenderId { get; set; }
        public Guid RFStatusId { get; set; }
        public Guid RFJenisPermohonanId { get; set; }
        public string RFSectorLBU1Code { get; set; }
        public string RFSectorLBU2Code { get; set; }
        public string RFSectorLBU3Code { get; set; }
        public int? RFZipCodeId { get; set; }
        public Guid RFKategoriId { get; set; }
        public Guid? RFKodeDinasId { get; set; }
        public int? RFStagesId { get; set; }
        public int? RFZipCodeUsahaId { get; set; }
        public Guid? RFKelompokUsahaId { get; set; }
        public Guid? RFJenisUsahaId { get; set; }
        public int? RFZipCodeTempatId { get; set; }
    }
}
