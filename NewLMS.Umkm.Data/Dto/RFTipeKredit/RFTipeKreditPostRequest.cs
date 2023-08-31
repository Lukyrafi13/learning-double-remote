using System;
namespace NewLMS.UMKM.Data.Dto.RfCreditTypes
{
    public class RfCreditTypePostRequestDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? CreditAgreement { get; set; }
    }
}
