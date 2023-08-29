using System;
namespace NewLMS.Umkm.Data.Dto.RFDocuments
{
    public class RFDocumentResponseDto
    {
        public Guid Id { get; set; }
        public string DocCode { get; set; }
        public string DocDesc { get; set; }
        public string GroupCode { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
        public int? Due { get; set; }
        public bool? Building { get; set; }
        public bool? ISTBO { get; set; }
        public bool? Mandatory { get; set; }
    }
}
