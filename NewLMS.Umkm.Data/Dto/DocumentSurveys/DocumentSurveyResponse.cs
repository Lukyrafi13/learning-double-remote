using NewLMS.Umkm.Data.Dto.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.DocumentSurveys
{
    public class DocumentSurveyResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public Guid LoanApplicationId { get; set; }
        public string DocumentType { get; set; }
        public string Title { get; set; }

        public ICollection<DocumentFileUrlRes> Files { get; set; }
    }
}
