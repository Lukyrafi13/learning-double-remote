using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class AnalisaSyaratKredit : BaseEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("AnalisaId")]
        public Analisa Analisa { get; set; }
        [ForeignKey("RFJenisSyaratKreditId")]
        public RFJenisSyaratKredit JenisSyaratKredit { get; set; }
        public string Deskripsi { get; set; }
        [ForeignKey("RFDecisionSKId")]
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