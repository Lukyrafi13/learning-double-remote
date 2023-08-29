using System;
namespace NewLMS.UMKM.Data.Dto.RFBanks
{
    public class RFBankResponseDto
    {
        public Guid Id { get; set; }
        public string BankId { get; set; }
        public string BankName { get; set; }
        public string CoreCode { get; set; }
        public bool? Active { get; set; }
    }
}
