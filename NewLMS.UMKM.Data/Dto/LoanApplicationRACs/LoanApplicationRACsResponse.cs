using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationRACs
{
    public class LoanApplicationRACsResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public bool? MinimumAge { get; set; }
        public bool? MaximumAge { get; set; }
        public bool? IdentityCard { get; set; }
        public bool? NationalBlacklist { get; set; }
        public bool? BICollectibility { get; set; }
        public bool? NotCollectibility { get; set; }
        public bool? HasAge { get; set; }
        public bool? HasNoCreditFacilities { get; set; }
        public bool? NeverReceivedCredit { get; set; }
        public bool? BPJSTKParticipants { get; set; }
    }
}
