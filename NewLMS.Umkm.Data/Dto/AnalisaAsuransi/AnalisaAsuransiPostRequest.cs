using System;

namespace NewLMS.Umkm.Data.Dto.AnalisaAsuransis
{
    public class AnalisaAsuransiPostRequestDto
    {
        public Guid Id { get; set; }
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
