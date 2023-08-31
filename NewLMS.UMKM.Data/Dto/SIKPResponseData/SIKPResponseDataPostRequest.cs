using System;

namespace NewLMS.UMKM.Data.Dto.SIKPResponseDatas
{
    public class SIKPResponseDataPostRequestDto
    {
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
    }
}
