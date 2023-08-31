using System;
using NewLMS.UMKM.Data.Dto.CompanyEntities;

namespace NewLMS.UMKM.Data.Dto.LoanApplications
{
    public class LoanApplicationPemohonBadanUsaha
    {
        public Guid Id {get; set;}
        public CompanyEntityPostRequestDto CompanyEntity {get; set;}

    }
}
