using System;
namespace NewLMS.UMKM.Data.Dto.RfCompanyGroups
{
    public class RfCompanyGroupResponseDto
    {
        public Guid Id { get; set; }
        public string AnlCode { get; set; }
        public string AnlDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
