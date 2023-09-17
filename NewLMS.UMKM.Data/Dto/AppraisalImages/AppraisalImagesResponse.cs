using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data.Dto.Documents;
using System;
using System.Collections.Generic;

namespace NewLMS.UMKM.Data.Dto.AppraisalImages
{
    public class AppraisalImagesResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public Guid AppraisalGuid { get; set; }
        public int DocumentType { get; set; }
        public string Title { get; set; }

        public RfParameterDetailSimpleResponse RfDocumentType { get; set; }
        public DocumentFileUrlRes Files { get; set; }
    }
}
