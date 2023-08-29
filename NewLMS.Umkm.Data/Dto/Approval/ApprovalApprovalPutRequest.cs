using System;
namespace NewLMS.Umkm.Data.Dto.Approvals
{
    public class ApprovalApprovalPutRequestDto
    {
        public Guid Id { get; set; }
        public bool? BacaDanSetuju { get; set; }
        public string Covenant { get; set; }
    }
}
