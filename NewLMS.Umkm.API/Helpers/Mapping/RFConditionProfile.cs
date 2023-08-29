using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFConditions;

namespace NewLMS.UMKM.API.Helpers.Mapping

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