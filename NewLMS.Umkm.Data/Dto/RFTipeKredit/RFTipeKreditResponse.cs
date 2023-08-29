using System;
namespace NewLMS.Umkm.Data.Dto.RFTipeKredits
{
    public class RFTipeKreditResponseDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? CreditAgreement { get; set; }
    }
}
