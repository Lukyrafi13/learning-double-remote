using System;

namespace NewLMS.UMKM.Data.Dto.AnalisaSyaratKredits
{
    public class AnalisaSyaratKreditPostRequestDto
    {
        public string Deskripsi { get; set; }
        public string By { get; set; }
        public string Catatan { get; set; }
        public int? Sequence { get; set; }
        public bool? Verifikasi { get; set; }

        public Guid AnalisaId { get; set; }
        public Guid? RFJenisSyaratKreditId { get; set; }
        public Guid? RFDecisionSKId { get; set; }
    }
}
