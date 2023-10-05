using System;
namespace NewLMS.Umkm.Data.Dto.FileUrls
{
    public class FileUrlResponse
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string FileSize { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
    }

    public class FileUrlSimpleResponse
    {
        public string FileName { get; set; }
        public string Url { get; set; }
        public string FileType { get; set; }
    }
}

