using System;
namespace NewLMS.Umkm.Data.Dto.RFMappingPrescreeningDocuments
{
    public class RFMappingPrescreeningDocumentResponseDto : BaseResponse
    {
        public int Id { get; set; }
        public string TypeCode { get; set; }
        public string ProductId { get; set; }
        public string OwnCode { get; set; }
        public string DocCode { get; set; }
        public RFDocument RFDocument { get; set; }
    }
}
