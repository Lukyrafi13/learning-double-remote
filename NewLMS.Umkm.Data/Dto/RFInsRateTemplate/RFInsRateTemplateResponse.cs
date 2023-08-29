using System;
namespace NewLMS.UMKM.Data.Dto.RFInsRateTemplates
{
    public class RFInsRateTemplateResponseDto
    {
        Guid Id {get; set; }
        public string TPLCode { get; set; }
        public string TPLDesc { get; set; }
        public bool? Active { get; set; }
    }
}
