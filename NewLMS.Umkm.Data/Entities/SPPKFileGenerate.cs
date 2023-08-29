using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class SPPKFileGenerate : BaseEntity
    {
        public Guid Id { get; set; }        
        [ForeignKey("SPPKId")]
        public SPPK SPPK { get; set; }
        [ForeignKey("FileUrlId")]
        public FileUrl FileUrl { get; set; }
        public string Type { get; set; }
        public string NamaFile { get; set; }
        public double? Ukuran { get; set; }
        public DateTime? TanggalModifikasi { get; set; }

        public Guid SurveyId { get; set; }
        public Guid? FileUrlId { get; set; }
    }
}