using System;
namespace NewLMS.Umkm.Data.Dto.RFTermConditions
{
    public class RFTermConditionResponseDto
    {
        public Guid Id { get; set; }
        public string TermCode { get; set; }
        public string TermDesc { get; set; }
        public string TemplateCode { get; set; }
        public string CoreCode { get; set; }
        public string SIKPCode { get; set; }
        public bool? Active { get; set; }
        public bool? SyaratBTB { get; set; }
        public string Note { get; set; }
        public bool? Verified { get; set; }
        public bool? Locked { get; set; }
    }
}
