using System;
namespace NewLMS.Umkm.Data.Dto.RFPaymentMethods
{
    public class RFPaymentMethodResponseDto
    {
        public Guid Id { get; set; }
        public string PAY_CODE { get; set; }
        public string PAY_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool Active { get; set; }
    }
}
