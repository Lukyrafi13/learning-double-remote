using System;
namespace NewLMS.UMKM.Data.Dto.LoanApplications
{
    public class LoanApplicationProsesResponseDto
    {
        public Guid? LoanApplicationId { get; set; }
        public Guid? SLIKId { get; set; }
        public Guid? SIKPId { get; set; }
        public Guid? PrescreeningId { get; set; }
        public Guid? AppraisalId { get; set; }
        public string Stage { get; set; }
        public string Message { get; set; }
    }
}
