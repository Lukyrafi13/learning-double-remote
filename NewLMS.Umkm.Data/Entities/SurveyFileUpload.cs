using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class SurveyFileUpload : BaseEntity
    {
        public Guid Id { get; set; }        
        [ForeignKey("SurveyId")]
        public Survey Survey { get; set; }
        [ForeignKey("FileUrlId")]
        public FileUrl FileUrl { get; set; }
        public string Judul { get; set; }
        public DateTime? TanggalUpload { get; set; }
        public string UploadOleh { get; set; }

        public Guid SurveyId { get; set; }
        public Guid? FileUrlId { get; set; }
    }
}