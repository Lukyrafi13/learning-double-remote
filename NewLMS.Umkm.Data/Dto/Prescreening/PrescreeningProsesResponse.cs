using System;
namespace NewLMS.UMKM.Data.Dto.Prescreenings
{
    public class PrescreeningProsesResponse
    {
        public Guid? AppId { get; set; }
        public Guid? PrescreeningId { get; set; }
        public Guid? SurveyId { get; set; }
        public string Stage { get; set; }
        public string Message { get; set; }
    }
}
