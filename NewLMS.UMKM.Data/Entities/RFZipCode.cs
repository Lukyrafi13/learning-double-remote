using System.ComponentModel.DataAnnotations;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfZipCode : BaseEntity
    {
        [Key]
        [Required]
		public int Id { get; set; }
		public string ZipCode { get; set; }
		public int Seq { get; set; }
		public string ZipDesc { get; set; }
		public string Kelurahan { get; set; }
		public string Kecamatan { get; set; }
		public string Provinsi { get; set; }
		public string Kota { get; set; }
		public string Dati_II { get; set; }
		public string Dati_II_Code { get; set; }
		public string Negara { get; set; }
		public string SandiWilayahBI { get; set; }
		public bool Active { get; set; }
		public string KodeKabupaten { get; set; }
		public string KodeProvinsi { get; set; }
		public string KodeKabKota { get; set; }
		public string KodeKecamatan { get; set; }
		public string KodeKelurahan { get; set; }
	}
}
