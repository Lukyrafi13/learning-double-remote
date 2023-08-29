using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFInsRateTemplates;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFInsRateTemplateProfile : Profile
    {
        public RFInsRateTemplateProfile()
        {
            CreateMap<RFInsRateTemplatePostRequestDto, RFInsRateTemplate>();
            CreateMap<RFInsRateTemplatePutRequestDto, RFInsRateTemplate>();
            CreateMap<RFInsRateTemplateResponseDto, RFInsRateTemplate>().ReverseMap();
        }
    }
}