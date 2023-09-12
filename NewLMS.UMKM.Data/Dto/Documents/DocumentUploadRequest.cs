﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.Documents
{
    public class DocumentUploadRequest
    {
        public IList<IFormFile> Files { get; set; }
        public Guid LoanApplicationId { get; set; }
        public int DocumentType { get; set; }
        public string DocumentNo { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? DocumentStatusId { get; set; }
        public DateTime? TBODate { get; set; }
        public string TBODesc { get; set; }
        public string Justification { get; set; }
        public string DocumentId { get; set; }
    }
}
