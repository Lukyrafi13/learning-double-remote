using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class SPPKFileUpload : BaseEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("SPPKId")]
        public SPPK SPPK { get; set; }
        [ForeignKey("FileUrlId")]
        public FileUrl FileUrl { get; set; }
        public string Type { get; set; }
        public string NamaFile { get; set; }
        public string Judul { get; set; }
        public DateTime? TanggalUpload { get; set; }
        public string UploadOleh { get; set; }

        public Guid SPPKId { get; set; }
        public Guid? FileUrlId { get; set; }
    }
}