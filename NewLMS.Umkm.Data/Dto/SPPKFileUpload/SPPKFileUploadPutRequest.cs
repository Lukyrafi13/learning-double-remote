using System;

namespace NewLMS.UMKM.Data.Dto.SPPKFileUploads
{
    public class SPPKFileUploadPutRequestDto : SPPKFileUploadPostRequestDto
    {
        public Guid Id { get; set; }
    }
}
