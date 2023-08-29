using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace NewLMS.UMKM.Data.Dto.SPPKFileUploads
{
    public class SPPKFileUploadPostRequestDto
    {
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
