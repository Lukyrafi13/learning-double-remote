using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NewLMS.Umkm.Data
{
    public class Prospect : BaseEntity
    {
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string ProspectId { get; set; }
        [ForeignKey("DebiturId")]
        public Debitur Debitur { get; set; }

        [ForeignKey("RFProductId")]
        public RFProduct JenisProduk { get; set; }
        [ForeignKey("RFOwnerCategoryId")]
        public RFOwnerCategory TipeDebitur { get; set; }
        public string NamaCustomer { get; set; }
        public string NamaDepanCustomer { get; set; }
        public string NamaTengahCustomer { get; set; }
        public string NamaBelakangCustomer { get; set; }
        [ForeignKey("RFGenderId")]
        public RFGender JenisKelamin { get; set; }
        public string StatusPerusahaan { get; set; }
        public string NomorTelpon { get; set; }
        public string NomorKTP { get; set; }
        public string TempatLahir { get; set; }
        public DateTime? TanggalLahir { get; set; }

        // Alamat Debitor
        public string Alamat { get; set; }
        [ForeignKey("RFZipCodeId")]
        public RFZipCode KodePos { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string KabupatenKota { get; set; }
        public string Propinsi { get; set; }

        // Alamat Tempat
        public bool AlamatSesuaiKTP { get; set; }
        public string AlamatTempat { get; set; }
        [ForeignKey("RFZipCodeTempatId")]
        public RFZipCode KodePosTempat { get; set; }
        public string KelurahanTempat { get; set; }
        public string KecamatanTempat { get; set; }
        public string KabupatenKotaTempat { get; set; }
        public string PropinsiTempat { get; set; }

        // Target
        public string NamaAO { get; set; }
        public string KodeCabang { get; set; }
        public string NamaCabang { get; set; }
        [ForeignKey("RFJenisPermohonanId")]
        public RFJenisPermohonan JenisPermohonanKredit { get; set; }
        [ForeignKey("RFStatusId")]
        public RFStatusTarget Status { get; set; }
        [ForeignKey("RFSectorLBU1Code")]
        public RFSectorLBU1 SektorEkonomi { get; set; }
        [ForeignKey("RFSectorLBU2Code")]
        public RFSectorLBU2 SubSektorEkonomi { get; set; }
        [ForeignKey("RFSectorLBU3Code")]
        public RFSectorLBU3 SubSubSektorEkonomi { get; set; }
        public string Alasan { get; set; }
        public double PerkiraanPengajuan { get; set; }
        public DateTime TanggalProspect { get; set; }

        // Data Usaha - Perorangan
        public string NamaUsaha { get; set; }
        public string AlamatUsaha { get; set; }
        public string AlamatLengkapUsaha { get; set; }
        [ForeignKey("RFZipCodeUsahaId")]
        public RFZipCode KodePosUsaha { get; set; }
        public string KelurahanUsaha { get; set; }
        public string KecamatanUsaha { get; set; }
        public string KabupatenKotaUsaha { get; set; }
        public string PropinsiUsaha { get; set; }

        // Data Usaha - Badan Usaha
        [ForeignKey("RFKelompokUsahaId")]
        public RFKelompokUsaha KelompokBidangUsaha { get; set; } 
        [ForeignKey("RFJenisUsahaId")]
        public RFJenisUsaha JenisUsaha { get; set; }
        public string JenisUsahaLain { get; set; }

        // etc
        public string SumberData { get; set; }
        [ForeignKey("RFStagesId")]
        public RFStages Stage { get; set; }

        [ForeignKey("RFPreviousStagesId")]
        public RFStages PreviousStage { get; set; }

        
        [ForeignKey("RFKategoriId")]
        public RFKategori Kategori { get; set; } 
        [ForeignKey("RFKodeDinasId")]
        public RFKodeDinas KodeDinas { get; set; }

        // Foreign keys
        
        public Guid RFProductId { get; set; }
        public Guid RFOwnerCategoryId { get; set; }
        public Guid? RFGenderId { get; set; }
        public Guid RFStatusId { get; set; }
        public Guid RFJenisPermohonanId { get; set; }
        public Guid DebiturId { get; set; }
        public string RFSectorLBU1Code { get; set; }
        public string RFSectorLBU2Code { get; set; }
        public string RFSectorLBU3Code { get; set; }
        public int? RFZipCodeId { get; set; }
        public Guid RFKategoriId { get; set; }
        public Guid? RFKodeDinasId { get; set; }
        public int? RFStagesId { get; set; }
        public int? RFPreviousStagesId { get; set; }
        public int? RFZipCodeUsahaId { get; set; }
        public Guid? RFKelompokUsahaId { get; set; }
        public Guid? RFJenisUsahaId { get; set; }
        public int? RFZipCodeTempatId { get; set; }
        public int? Age =>AgeStage("1.0");
        public int? AgeRejected =>AgeStage("0.0");

        // One to One
        public App App { get; set; }

        // One to many
        public ICollection<ProspectStageLogs> ProspectStageLogs {get; set;}

        public int AgeStage(string stageCode){
            if (ProspectStageLogs == null){
                return -1;
            }

            var LatestStageLog = ProspectStageLogs
            .Where(x=> x.RFStages?.Code == stageCode)
            .OrderBy(x=>x.CreatedDate).ToList().FirstOrDefault();

            return LatestStageLog == null ? -1 :(DateTime.Now.ToLocalTime() - LatestStageLog.CreatedDate).Days;
        }

    }
}