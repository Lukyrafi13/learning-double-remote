﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.FileUpload.Models
{
    public class UploadRequestModel
    {
        public string Segment { get; set; }
        public string DebtorName { get; set; }
        public string LoanApplicationId { get; set; }
        public string DocumentName { get; set; }
        public IFormFile File { get; set; }
    }
}
