using System;
namespace NewLMS.UMKM.Data.Dto.SurveyBuyers
{
    public class SurveyBuyerResponseDto : SurveyBuyerPostRequestDto
    {
        public Guid Id { get; set; }
        public Survey Survey { get; set; }
        public RFPaymentMethod MetodePembayaran { get; set; }
    }
}
