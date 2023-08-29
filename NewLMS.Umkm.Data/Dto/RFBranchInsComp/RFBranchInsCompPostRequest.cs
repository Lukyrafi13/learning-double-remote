using System;
namespace NewLMS.UMKM.Data.Dto.RFBranchInsComps
{
    public class RFBranchInsCompPostRequestDto
    {
        public string BranchId { get; set; }
        public string CompId { get; set; }
        public string TPLCode { get; set; }
        public bool? Active { get; set; }
    }
}
