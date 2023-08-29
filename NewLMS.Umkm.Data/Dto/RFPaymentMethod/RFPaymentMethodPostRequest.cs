namespace NewLMS.UMKM.Data.Dto.RFPaymentMethods
{
    public class RFPaymentMethodPostRequestDto
    {
        public string PAY_CODE { get; set; }
        public string PAY_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool Active { get; set; }
    }
}
