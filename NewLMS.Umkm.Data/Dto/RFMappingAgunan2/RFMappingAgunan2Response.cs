using System;
namespace NewLMS.UMKM.Data.Dto.RFMappingAgunan2s
{
    public class RFMappingAgunan2ResponseDto
    {
        public Guid Id { get; set; }
        public string ProductId { get; set; }
        public string ColCode { get; set; }
        public string ColDesc { get; set; }
        public bool Active { get; set; }
    }
}
