using System;
namespace NewLMS.UMKM.Data.Dto.RFDocumentAgunans
{
    public class RFDocumentAgunanResponseDto
    {
        public Guid Id { get; set; }
        public string DocCode { get; set; }
        public string ColCode { get; set; }
        public bool Active { get; set; }
    }
}
