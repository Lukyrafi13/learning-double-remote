using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationRACs
{
    public class LoanApplicationRACRequest
    {
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
