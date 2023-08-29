using System;
namespace NewLMS.Umkm.Data.Dto.Reviews
{
    public class ReviewProsesResponse
    {
        public Guid? AppId { get; set; }
        public Guid? ReviewId { get; set; }
        public Guid? ApprovalId { get; set; }
        public string Stage { get; set; }
        public string Message { get; set; }
    }
}
