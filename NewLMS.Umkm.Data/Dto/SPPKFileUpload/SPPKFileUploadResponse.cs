using System;
namespace NewLMS.Umkm.Data.Dto.SPPKFileUploads
{
    public class SPPKFileUploadResponseDto
    {
        public Guid Id { get; set; }
        public SPPK SPPK { get; set; }
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
