using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFConditions;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFConditionProfile : Profile
    {
        public RFConditionProfile()
        {
            CreateMap<RFConditionPostRequestDto, RFCondition>();
            CreateMap<RFConditionPutRequestDto, RFCondition>();
            CreateMap<RFConditionResponseDto, RFCondition>().ReverseMap();
        }
    }
}