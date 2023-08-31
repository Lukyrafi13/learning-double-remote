using System;
namespace NewLMS.UMKM.Data.Dto.RfCreditTypes
{
    public class RfCreditTypeResponseDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? CreditAgreement { get; set; }
    }
}
