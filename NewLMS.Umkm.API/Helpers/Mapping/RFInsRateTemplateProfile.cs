using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFInsRateTemplates;

namespace NewLMS.UMKM.API.Helpers.Mapping

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