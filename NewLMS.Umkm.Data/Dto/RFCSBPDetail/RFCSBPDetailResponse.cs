using System;
namespace NewLMS.Umkm.Data.Dto.RFCSBPDetails
{
    public class RFCSBPDetailResponseDto
    {
        public Guid Id { get; set; }
        public string CSBPGroupID { get; set; }
        public string CSBPDetailID { get; set; }
        public string CSBPDetailName { get; set; }
        public string CSBPDetailDesc { get; set; }
    }
}
