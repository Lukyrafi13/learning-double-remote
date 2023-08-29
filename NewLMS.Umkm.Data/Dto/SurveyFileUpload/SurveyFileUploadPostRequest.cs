using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace NewLMS.Umkm.Data.Dto.SurveyFileUploads
{
    public class SurveyFileUploadPostRequestDto
    {
        public string Judul { get; set; }
        public string UploadOleh { get; set; }
        public IFormFile File { get; set; }
        public Guid SurveyId { get; set; }
    }
}
