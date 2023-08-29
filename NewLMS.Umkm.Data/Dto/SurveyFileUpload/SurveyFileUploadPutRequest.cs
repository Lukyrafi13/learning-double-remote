using System;

namespace NewLMS.Umkm.Data.Dto.SurveyFileUploads
{
    public class SurveyFileUploadPutRequestDto : SurveyFileUploadPostRequestDto
    {
        public Guid Id { get; set; }
    }
}
