using System;
namespace NewLMS.UMKM.Data.Dto.FileUrls
{
    public class FileUrlPutRequestDto : FileUrlPostRequestDto
    {
        public Guid Id { get; set; }
    }
}
