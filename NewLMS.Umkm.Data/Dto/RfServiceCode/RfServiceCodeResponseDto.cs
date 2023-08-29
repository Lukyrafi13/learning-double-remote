using System;
namespace NewLMS.UMKM.Data.Dto.RfServiceCodes
{
    public class RfServiceCodeResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string ServiceCode { get; set; }
        public string Partner { get; set; }
        public string EconomySector { get; set; }
        public string Cultivation { get; set; }
        public bool Active { get; set; }
    }
}
