using System;
namespace NewLMS.Umkm.Data.Dto.SurveyFileUploads
{
    public class SurveyFileUploadResponseDto
    {
        public Guid Id { get; set; }
        public string Judul { get; set; }
        public string UploadOleh { get; set; }
        public DateTime? TanggalUpload { get; set; }
        public Survey Survey { get; set; }
        public FileUrl FileUrl { get; set; }
        public Guid? FileUrlId { get; set; }
        public Guid SurveyId { get; set; }
    }
}
