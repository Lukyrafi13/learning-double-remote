using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace NewLMS.Umkm.Data
{
    public class Debitur : BaseEntity
    {
        [Key]
        [Required]
		public Guid Id { get; set; }
		public string NamaLengkap { get; set; }
        [ForeignKey("RFGenderId")]
        public RFGender JenisKelamin { get; set; }

		[MaxLength(16)]
		public string NomorKTP { get; set; }
		public string NomorTelpon { get; set; }
		public string AlamatKTP { get; set; }
        [ForeignKey("RFZipCodeId")]
        public RFZipCode KodePos { get; set; }
		public string Kelurahan { get; set; }
		public string Kecamatan { get; set; }
		public string KabupatenKota { get; set; }
		public string Propinsi { get; set; }
		public bool AlamatSesuaiKTP { get; set; }
		public string AlamatTempatTinggal { get; set; }
        [ForeignKey("RFZipCodeTempatTinggalId")]
        public RFZipCode KodePosTempatTinggal { get; set; }
		public string KelurahanTempatTinggal { get; set; }
		public string KecamatanTempatTinggal { get; set; }
		public string KabupatenKotaTempatTinggal { get; set; }
		public string PropinsiTempatTinggal { get; set; }
		public string NoTelpDapatDihubungi { get; set; }
		public string NomorHP { get; set; }
		public string TempatLahir { get; set; }
        public DateTime? TanggalLahir { get; set; }
        [ForeignKey(nameof(JenisKelamin))]
        public Guid? RFGenderId { get; set; }
        public int? RFZipCodeId { get; set; }
        public int? RFZipCodeTempatTinggalId { get; set; }

	}
}
