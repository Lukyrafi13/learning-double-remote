using System;

namespace NewLMS.UMKM.Data.Dto.Apps
{
    public class AppInboxResponse
    {
        public Guid Id { get; set; }
        public string LoanApplicationId { get; set; }
        public string Fullname { get; set; }
        public string Product { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string Stage { get; set; }
        public string Segment { get; set; }
        public DateTime EntryDate { get; set; }
        public int Aging { get; set; }
        public string Url { get; set; }
        public string NoIdentity { get; set; }
    }


    public class PaginationRequest
    {
        public int Page { get; set; }
        public int Length { get; set; }
    }
}
