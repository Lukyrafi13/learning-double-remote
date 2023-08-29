using System;
namespace NewLMS.Umkm.Data.Dto.SurveyBuyers
{
    public class SurveyBuyerResponseDto : SurveyBuyerPostRequestDto
    {
        public Guid Id { get; set; }
        public Survey Survey { get; set; }
        public RFPaymentMethod MetodePembayaran { get; set; }
    }
}
