namespace NewLMS.Umkm.Data.Dto.RfBanks
{
    public class RfBankResponse : BaseResponse
    {
        public string BankId { get; set; }

        public string BankName { get; set; }

        public string CoreCode { get; set; }

        public bool Active { get; set; }
    }
}
