using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class FileDokumen : BaseEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("PrescreeningDokumenId")]
        public PrescreeningDokumen PrescreeningDokumen { get; set; }
        [ForeignKey("FileUrlId")]
        public FileUrl FileUrl { get; set; }
        public string DocumentSubType { get; set; }
        public bool? Active { get; set; }

        public Guid? PrescreeningDokumenId { get; set; }
        public Guid? FileUrlId { get; set; }
    }
}