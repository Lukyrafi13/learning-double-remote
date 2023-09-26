using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace NewLMS.Umkm.Data.Dto.Documents
{
    public class DocumentUpdateRequest
    {
        public IList<IFormFile> Files { get; set; }
        public Guid Id { get; set; }
        public Guid LoanApplicationId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNo { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? DocumentStatusId { get; set; }
        public DateTime? TBODate { get; set; }
        public string TBODesc { get; set; }
        public string Justification { get; set; }
        public string DocumentCategory { get; set; }
    }
}
