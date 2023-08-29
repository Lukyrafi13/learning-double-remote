using System;

namespace NewLMS.Umkm.Data.Dto.SIKPCalonDebiturs
{
    public class SIKPCalonDebiturPostRequestDto
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
    }
}
