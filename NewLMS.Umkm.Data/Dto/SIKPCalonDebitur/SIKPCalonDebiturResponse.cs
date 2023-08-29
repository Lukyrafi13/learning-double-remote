using System;
namespace NewLMS.Umkm.Data.Dto.SIKPCalonDebiturs
{
    public class SIKPCalonDebiturResponseDto
    {        
        public Guid Id { get; set; }

        public App App { get; set; }

        // Data IDE
        public RFOwnerCategory TipeDebitur { get; set; }
        public RFSectorLBU1 SektorEkonomi { get; set; }
        public RFSectorLBU2 SubSektorEkonomi { get; set; }
        public RFSectorLBU3 SubSubSektorEkonomi { get; set; }
        public RFGender JenisKelamin { get; set; }
        public RFMARITAL StatusPernikahan { get; set; }
        public RFEDUCATION PendidikanTerakhir { get; set; }
        public RFJOB DataPekerjaan { get; set; }
        public RFZipCode KodePos { get; set; }
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
        public RFZipCode KodePosUsaha { get; set; }
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
        public RFGender JenisKelaminSIKP { get; set; }
        public RFMARITAL StatusPernikahanSIKP { get; set; }
        public RFEDUCATION PendidikanTerakhirSIKP { get; set; }
        public RFJOB DataPekerjaanSIKP { get; set; }
        public RFZipCode KodePosSIKP { get; set; }
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
        public RFZipCode KodePosUsahaSIKP { get; set; }
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
        public Guid? RFOwnerCategoryId { get; set; }
        public string? RFSectorLBU1Code { get; set; }
        public string? RFSectorLBU2Code { get; set; }
        public string? RFSectorLBU3Code { get; set; }
        public Guid? RFGenderId { get; set; }
        public Guid? RFMaritalId { get; set; }
        public Guid? RFEducationId { get; set; }
        public Guid? RFJobId { get; set; }
        public int? RFZipCodeId { get; set; }
        public int? RFZipCodeUsahaId { get; set; }
        public Guid? RFLinkageUsahaId { get; set; }
        public Guid? RFGenderSIKPId { get; set; }
        public Guid? RFMaritalSIKPId { get; set; }
        public Guid? RFEducationSIKPId { get; set; }
        public Guid? RFJobSIKPId { get; set; }
        public int? RFZipCodeSIKPId { get; set; }
        public int? RFZipCodeUsahaSIKPId { get; set; }
        public Guid? RFLinkageUsahaSIKPId { get; set; }

    }
}
