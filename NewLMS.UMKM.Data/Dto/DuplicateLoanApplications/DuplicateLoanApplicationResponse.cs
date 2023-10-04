using NewLMS.Umkm.Data.Dto.MSearch;
using System.Collections.Generic;

namespace NewLMS.Umkm.Data.Dto.DuplicateLoanApplications
{
    public class DuplicateLoanApplicationResponse
    {
        public DuplicateLoanApplicationLMSResponse Internal { get; set; }
        public DuplicateLoanApplicationLMSResponse Core { get; set; }
        public DuplicateLoanApplicationLMSResponse DHN { get; set; }
    }

    public class DuplicateLoanApplicationDetailResponse
    {
        public bool IsDuplicate { get; set; }
        public List<MSearchResponse> MSearch { get; set; }
    }

    public class DuplicateLoanApplicationLMSResponse : DuplicateLoanApplicationDetailResponse
    {

    }
    public class DuplicateLoanApplicationCoreResponse : DuplicateLoanApplicationDetailResponse
    {

    }
    public class DuplicateLoanApplicationDHNResponse : DuplicateLoanApplicationDetailResponse
    {

    }
}
