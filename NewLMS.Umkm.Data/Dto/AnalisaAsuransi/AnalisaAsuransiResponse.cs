using System;
namespace NewLMS.UMKM.Data.Dto.AnalisaAsuransis
{
    public class AnalisaAsuransiResponseDto
    {
        public Guid Id { get; set; }
        public Analisa Analisa { get; set; }
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
