using System;

namespace NewLMS.UMKM.Data.Dto.SurveyBuyers
{
    public class SurveyBuyerPutRequestDto : SurveyBuyerPostRequestDto
    {
        public Guid Id { get; set; }
    }
}
