using System;
namespace NewLMS.Umkm.Data.Dto.RFConditions
{
    public class RFConditionResponseDto
    {
        public Guid Id { get; set; }
        public string ConditionCode { get; set; }
        public string ConditionDesc { get; set; }
        public string ConditionCategory { get; set; }
        public bool? Active { get; set; }
    }
}
