using System;
namespace NewLMS.Umkm.Data.Dto.RFRelationSurveys
{
    public class RFRelationSurveyResponseDto
    {
        public Guid Id { get; set; }
        public string RE_CODE { get; set; }
        public string RE_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
    }
}
