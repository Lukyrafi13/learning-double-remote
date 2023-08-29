namespace NewLMS.UMKM.Data.Dto.RFLoanPurposes
{
    public class RFLoanPurposePostRequestDto
    {
        public string LP_CODE { get; set;}
        public string LP_DESC { get; set;}
        public string CORE_CODE { get; set;}
        public bool Active { get; set;}
        public int? MAXPROD { get; set;}
    }
}
