using System;
namespace NewLMS.Umkm.Data.Dto.RFBranchInsComps
{
    public class RFBranchInsCompResponseDto
    {
        public int Id { get; set; }
        public string BranchId { get; set; }
        public string CompId { get; set; }
        public string TPLCode { get; set; }
        public bool? Active { get; set; }
    }
}
