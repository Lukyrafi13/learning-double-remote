using System;
namespace NewLMS.Umkm.Data.Dto.RFSubProductTenors
{
    public class RFSubProductTenorResponseDto
    {
        public Guid Id { get; set; }
        public string SubProductId { get; set;}
        public string TNCode { get; set;}
        public bool Active { get; set;}
    }
}
