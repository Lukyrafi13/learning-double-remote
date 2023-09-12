using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.FileUpload.Models
{
    public class GenerateFileRequestModel
    {
        public string Segment { get; set; }
        public string DebtorName { get; set; }
        public string LoanApplicationId { get; set; }
        public string FileTemplate { get; set; }
        public Byte[] File { get; set; }
    }
}
