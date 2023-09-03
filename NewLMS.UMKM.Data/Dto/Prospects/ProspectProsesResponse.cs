using System;
namespace NewLMS.UMKM.Data.Dto.Prospects
{
    public class ProspectProsesResponseDto
    {
        public Guid ProspectId { get; set; }
        public Guid? AppId { get; set; }
        public string Stage { get; set; }
        public string Message { get; set; }
    }
}
