using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.DocumentSurveyors
{
    public class DocumentSurveyorUploadRequest
    {
        public IFormFile Files { get; set; }
        public Guid AppraisalGuid { get; set; }
        public string DocumentType { get; set; }
        public string Title { get; set; }
    }
}
