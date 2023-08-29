using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class AnalisaAsuransi : BaseEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("AnalisaId")]
        public Analisa Analisa { get; set; }
        [ForeignKey("RFJenisAsuransiId")]
        public RFJenisAsuransi RFJenisAsuransi { get; set; }
        public string Agunan { get; set; }
        public string NamaLengkap { get; set; }
        public string NamaPerusahaanAsuransi { get; set; }
        public double? Rate { get; set; }
        public double? Premi { get; set; }
        public string LoanType { get; set; }
        public string TujuanPenggunaan { get; set; }
        public bool? Asuransikan { get; set; }

        public Guid AnalisaId { get; set; }
        public Guid? RFJenisAsuransiId { get; set; }
    }
}