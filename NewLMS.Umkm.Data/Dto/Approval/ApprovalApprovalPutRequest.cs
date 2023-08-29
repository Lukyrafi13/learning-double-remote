using System;
namespace NewLMS.UMKM.Data.Dto.Approvals
{
    public class ApprovalApprovalPutRequestDto
    {
        public Guid Id { get; set; }
        public bool? BacaDanSetuju { get; set; }
        public string Covenant { get; set; }
    }
}
