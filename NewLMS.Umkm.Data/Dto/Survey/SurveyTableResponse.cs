using System;

namespace NewLMS.Umkm.Data.Dto.Surveys
{
    public class SurveyTableResponse
    {
        public Guid Id { get; set; }
        public Guid? InformasiOmsetId { get; set; }
        public DateTime? TanggalRequest { get; set; }
        public string StatusSLIK { get; set; }
        public int Age { get; set; }

        public App App { get; set; }
    }
}
