using System;

namespace NewLMS.UMKM.Data.Dto.AppContactPersons
{
    public class AppContactPersonPutRequestDto : AppContactPersonPostRequestDto
    {
        public Guid Id { get; set; }
    }
}
