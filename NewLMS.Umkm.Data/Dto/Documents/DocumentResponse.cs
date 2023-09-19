using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.Umkm.Data.Dto.RfDocument;
using System;
using System.Collections.Generic;

namespace NewLMS.Umkm.Data.Dto.Documents
{
    public class DocumentResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public Guid LoanApplicationId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNo { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? DocumentStatusId { get; set; }
        public DateTime? TBODate { get; set; }
        public string TBODesc { get; set; }
        public string Justification { get; set; }
        public string DocumentId { get; set; }

        public RfParameterDetailSimpleResponse RfDocumentStatus { get; set; }
        public RfDocumentResponse RfDocument { get; set; }
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
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string FileSize { get; set; }
        public string FileType { get; set; }
        public string UploadBy { get; set; }
        public string FileName { get; set; }
    }
}
