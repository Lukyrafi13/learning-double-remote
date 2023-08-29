using System;
namespace NewLMS.Umkm.Data.Dto.Approvals
{
    public class ApprovalProsesResponse
    {
        public Guid? AppId { get; set; }
        public Guid? ApprovalId { get; set; }
        public Guid? SPPKId { get; set; }
        public string Stage { get; set; }
        public string Message { get; set; }
    }
}
