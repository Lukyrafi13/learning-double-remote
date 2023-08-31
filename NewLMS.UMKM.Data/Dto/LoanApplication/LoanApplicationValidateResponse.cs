using System;
namespace NewLMS.UMKM.Data.Dto.LoanApplications
{
    public class LoanApplicationValidateResponse
    {
        public Guid Id { get; set; }
        public bool Valid { get; set; }
        public string Message { get; set; }
    }
}
