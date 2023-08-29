using System;
namespace NewLMS.Umkm.Data.Dto.Apps
{
    public class AppProsesResponseDto
    {
        public Guid? AppId { get; set; }
        public Guid? SLIKId { get; set; }
        public Guid? SIKPId { get; set; }
        public Guid? PrescreeningId { get; set; }
        public Guid? AppraisalId { get; set; }
        public string Stage { get; set; }
        public string Message { get; set; }
    }
}
