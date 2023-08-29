using System;
namespace NewLMS.Umkm.Data.Dto.RFConditions
{
    public class RFConditionPostRequestDto
    {
        public string ConditionCode { get; set; }
        public string ConditionDesc { get; set; }
        public string ConditionCategory { get; set; }
        public bool? Active { get; set; }
    }
}
