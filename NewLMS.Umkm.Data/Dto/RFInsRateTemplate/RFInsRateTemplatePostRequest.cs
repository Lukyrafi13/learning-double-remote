using System;
namespace NewLMS.Umkm.Data.Dto.RFInsRateTemplates
{
    public class RFInsRateTemplatePostRequestDto
    {
        public string TPLCode { get; set; }
        public string TPLDesc { get; set; }
        public bool? Active { get; set; }
    }
}
