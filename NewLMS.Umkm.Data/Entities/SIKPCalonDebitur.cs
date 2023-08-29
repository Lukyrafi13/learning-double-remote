using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class SIKPCalonDebitur : BaseEntity
    {
        public Guid Id { get; set; }

        [ForeignKey("AppId")]
        public App App { get; set; }

        // Data IDE
        [ForeignKey("RfOwnerCategoryId")]
        public RfOwnerCategory TipeDebitur { get; set; }
        [ForeignKey("RfSectorLBU1Code")]
        public RfSectorLBU1 SektorEkonomi { get; set; }
        [ForeignKey("RfSectorLBU2Code")]
        public RfSectorLBU2 SubSektorEkonomi { get; set; }
        [ForeignKey("RfSectorLBU3Code")]
        public RfSectorLBU3 SubSubSektorEkonomi { get; set; }
        [ForeignKey("RfGenderId")]
        public RfGender JenisKelamin { get; set; }
        [ForeignKey("RFMaritalId")]
        public RFMARITAL StatusPernikahan { get; set; }
        [ForeignKey("RFEducationId")]
        public RFEDUCATION PendidikanTerakhir { get; set; }
        [ForeignKey("RFJobId")]
        public RFJOB DataPekerjaan { get; set; }
        [ForeignKey("RfZipCodeId")]
        public RfZipCode KodePos { get; set; }
        public string NoCIF { get; set; }
        public string NoKTP { get; set; }
        public string NPWP { get; set; }
        public string NamaDebitur { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string Alamat { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string KabupatenKota { get; set; }
        public string Propinsi { get; set; }

        // Data Usaha
        [ForeignKey("RfZipCodeUsahaId")]
        public RfZipCode KodePosUsaha { get; set; }
        [ForeignKey("RFLinkageUsahaId")]
        public RFLinkage Linkage { get; set; }
        public DateTime? TanggalMulaiUsaha { get; set; }
        public string AlamatUsaha { get; set; }
        public string KelurahanUsaha { get; set; }
        public string KecamatanUsaha { get; set; }
        public string KabupatenKotaUsaha { get; set; }
        public string PropinsiUsaha { get; set; }
        public string IzinUsaha { get; set; }
        public double? ModalUsaha { get; set; }
        public double? JumlahKredit { get; set; }
        public string NoHP { get; set; }
        public string Agunan { get; set; }
        public int? JumlahPekerja { get; set; }
        public bool? StatusSubsidi { get; set; }
        public double? SubsidiSebelumnya { get; set; }


        // Data IDE SKIP
        [ForeignKey("RfGenderSIKPId")]
        public RfGender JenisKelaminSIKP { get; set; }
        [ForeignKey("RFMaritalSIKPId")]
        public RFMARITAL StatusPernikahanSIKP { get; set; }
        [ForeignKey("RFEducationSIKPId")]
        public RFEDUCATION PendidikanTerakhirSIKP { get; set; }
        [ForeignKey("RFJobSIKPId")]
        public RFJOB DataPekerjaanSIKP { get; set; }
        [ForeignKey("RfZipCodeSIKPId")]
        public RfZipCode KodePosSIKP { get; set; }
        public string NoRegistrasiSIKP { get; set; }
        public string NoKTPSIKP { get; set; }
        public string NPWPSIKP { get; set; }
        public string NamaDebiturSIKP { get; set; }
        public DateTime? TanggalLahirSIKP { get; set; }
        public string AlamatSIKP { get; set; }
        public string KelurahanSIKP { get; set; }
        public string KecamatanSIKP { get; set; }
        public string KabupatenKotaSIKP { get; set; }
        public string PropinsiSIKP { get; set; }



        // Data Usaha SIKP
        [ForeignKey("RfZipCodeUsahaSIKPId")]
        public RfZipCode KodePosUsahaSIKP { get; set; }
        [ForeignKey("RFLinkageUsahaSIKPId")]
        public RFLinkage LinkageSIKP { get; set; }
        public DateTime? TanggalMulaiUsahaSIKP { get; set; }
        public string AlamatUsahaSIKP { get; set; }
        public string KelurahanUsahaSIKP { get; set; }
        public string KecamatanUsahaSIKP { get; set; }
        public string KabupatenKotaUsahaSIKP { get; set; }
        public string PropinsiUsahaSIKP { get; set; }
        public string IzinUsahaSIKP { get; set; }
        public double? ModalUsahaSIKP { get; set; }
        public double? JumlahKreditSIKP { get; set; }
        public string NoHPSIKP { get; set; }
        public string AgunanSIKP { get; set; }
        public int? JumlahPekerjaSIKP { get; set; }
        public bool? StatusSubsidiSIKP { get; set; }
        public double? SubsidiSebelumnyaSIKP { get; set; }

        // Data result validasi SIKP
        public bool? Valid { get; set; }
        public string MessageValidasi { get; set; }

        // Foreign Keys
        public Guid AppId { get; set; }
        public Guid? RfOwnerCategoryId { get; set; }
        public string? RfSectorLBU1Code { get; set; }
        public string? RfSectorLBU2Code { get; set; }
        public string? RfSectorLBU3Code { get; set; }
        public Guid? RfGenderId { get; set; }
        public Guid? RFMaritalId { get; set; }
        public Guid? RFEducationId { get; set; }
        public Guid? RFJobId { get; set; }
        public int? RfZipCodeId { get; set; }
        public int? RfZipCodeUsahaId { get; set; }
        public Guid? RFLinkageUsahaId { get; set; }
        public Guid? RfGenderSIKPId { get; set; }
        public Guid? RFMaritalSIKPId { get; set; }
        public Guid? RFEducationSIKPId { get; set; }
        public Guid? RFJobSIKPId { get; set; }
        public int? RfZipCodeSIKPId { get; set; }
        public int? RfZipCodeUsahaSIKPId { get; set; }
        public Guid? RFLinkageUsahaSIKPId { get; set; }
    }
}
