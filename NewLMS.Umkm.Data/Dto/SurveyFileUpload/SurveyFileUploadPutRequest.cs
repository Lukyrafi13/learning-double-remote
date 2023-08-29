using System;

namespace NewLMS.UMKM.Data.Dto.SurveyFileUploads
{
    public class SurveyFileUploadPutRequestDto : SurveyFileUploadPostRequestDto
    {
        public Guid Id { get; set; }
    }
}
