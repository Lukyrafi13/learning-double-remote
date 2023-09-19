using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.Umkm.Data.Dto.Documents;
using System;
using System.Collections.Generic;

namespace NewLMS.Umkm.Data.Dto.AppraisalImages
{
    public class AppraisalImagesResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public Guid LoanApplicationId { get; set; }
        public Guid AppraisalGuid { get; set; }
        public string DocumentType { get; set; }
        public string Title { get; set; }

        public ICollection<DocumentFileUrlRes> Files { get; set; }
    }
}
