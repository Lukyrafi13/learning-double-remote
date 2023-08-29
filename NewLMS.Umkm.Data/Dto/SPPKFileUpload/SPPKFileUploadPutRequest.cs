using System;

namespace NewLMS.Umkm.Data.Dto.SPPKFileUploads
{
    public class SPPKFileUploadPutRequestDto : SPPKFileUploadPostRequestDto
    {
        public Guid Id { get; set; }
    }
}
