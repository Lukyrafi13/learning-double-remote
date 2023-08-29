using System;
namespace NewLMS.Umkm.Data.Dto.Surveys
{
    public class SurveyProsesResponse
    {
        public Guid? AppId { get; set; }
        public Guid? SurveyId { get; set; }
        public Guid? AnalisaId { get; set; }
        public string Stage { get; set; }
        public string Message { get; set; }
    }
}
