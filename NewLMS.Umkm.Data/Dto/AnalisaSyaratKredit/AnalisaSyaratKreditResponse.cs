using System;
namespace NewLMS.UMKM.Data.Dto.AnalisaSyaratKredits
{
    public class AnalisaSyaratKreditResponseDto
    {
        public Guid Id { get; set; }
        public Analisa Analisa { get; set; }
        public RFJenisSyaratKredit JenisSyaratKredit { get; set; }
        public string Deskripsi { get; set; }
        public RFDecisionSK Decision { get; set; }
        public string By { get; set; }
        public string Catatan { get; set; }
        public int? Sequence { get; set; }
        public bool? Verifikasi { get; set; }

        public Guid AnalisaId { get; set; }
        public Guid? RFJenisSyaratKreditId { get; set; }
        public Guid? RFDecisionSKId { get; set; }
    }
}
