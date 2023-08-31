using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationCreditFacilities
{
    public class LoanApplicationCreditFacilityPutRequestDto : LoanApplicationCreditFacilityPostRequestDto
    {
        public Guid Id { get; set; }
    }
}
