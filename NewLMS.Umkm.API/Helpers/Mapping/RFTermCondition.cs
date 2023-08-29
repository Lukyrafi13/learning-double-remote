using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFTermConditions;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFTermConditionProfile : Profile
    {
        public RFTermConditionProfile()
        {
            CreateMap<RFTermCondition, RFTermConditionResponseDto>().ReverseMap();
            CreateMap<RFTermConditionPostRequestDto, RFTermCondition>();
            CreateMap<RFTermConditionPutRequestDto, RFTermCondition>();
        }
    }
}