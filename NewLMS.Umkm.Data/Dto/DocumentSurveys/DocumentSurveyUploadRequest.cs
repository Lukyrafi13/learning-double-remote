using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.DocumentSurveys
{
    public class DocumentSurveyUploadRequest
    {
        public IList<IFormFile> Files { get; set; }
        public Guid LoanApplicationId { get; set; }
        public string DocumentType { get; set; }
        public DateTime UploadDate { get; set; }
        public string Title { get; set; }
    }
}
