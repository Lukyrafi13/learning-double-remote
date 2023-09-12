using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto.RfDocument;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.Documents
{
    public class DocumentResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public Guid LoanApplicationId { get; set; }
        public int DocumentType { get; set; }
        public string DocumentNo { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? DocumentStatusId { get; set; }
        public DateTime? TBODate { get; set; }
        public string TBODesc { get; set; }
        public string Justification { get; set; }
        public string DocumentId { get; set; }

        public RfParameterDetailSimpleResponse RfDocumentType { get; set; }
        public RfParameterDetailSimpleResponse RfDocumentStatus { get; set; }
        public RfDocumentSimpleResponse RfDocument { get; set; }
        public ICollection<DocumentFileUrlRes> Files { get; set; }
    }

    public class DocumentFileUrlRes : BaseResponse
    {
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public Guid FileUrlId { get; set; }
        public FileRes FileUrl { get; set; }
    }

    public class FileRes : BaseResponse
    {
        public Guid FileUrlId { get; set; }
        public string Url { get; set; }
        public string FileSize { get; set; }
        public string FileType { get; set; }
        public string UploadBy { get; set; }
        public string FileName { get; set; }
    }
}
