using System;
namespace NewLMS.UMKM.Data.Dto.FileUrls
{
    public class FileUrlResponseDto
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
		public string FileSize { get; set; }
		public string FileType { get; set; }
    }
}
