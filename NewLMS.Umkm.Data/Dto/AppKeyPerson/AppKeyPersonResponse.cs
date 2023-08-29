using System;
namespace NewLMS.Umkm.Data.Dto.AppKeyPersons
{
    public class AppKeyPersonResponseDto
    {
        public Guid Id { get; set; }        
        public App App { get; set; }
        public string Nama { get; set; }
        public string TempatLahir { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string Jabatan { get; set; }
        public string NoKTP { get; set; }
        public string NomorTelpon { get; set; }
        public DateTime? MasaBerlakuKTP { get; set; }
        public bool? SeumurHidup { get; set; }
        public string NPWP { get; set; }
        public RFEDUCATION PendidikanTerakhir { get; set; }
        public RFMARITAL Status { get; set; }
        public string Alamat { get; set; }
        public RFZipCode KodePos { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string KabupatenKota { get; set; }
        public string Propinsi { get; set; }
        public Guid AppId { get; set; }
        public Guid? RFEducationId { get; set; }
        public Guid? RFMaritalId { get; set; }
        public int? RFZipCodeId { get; set; }
    }
}
