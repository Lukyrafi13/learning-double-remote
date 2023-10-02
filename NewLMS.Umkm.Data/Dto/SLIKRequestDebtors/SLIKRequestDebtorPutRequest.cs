using Microsoft.AspNetCore.Http;

namespace NewLMS.Umkm.Data.Dto.SLIKRequestDebtors
{
    public class SLIKRequestDebtorPutRequest : SLIKRequestDebtorRequest
    {
        public IFormFile? Files { get; set; }
    }
}

