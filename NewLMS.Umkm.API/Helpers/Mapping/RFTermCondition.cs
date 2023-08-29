using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFTermConditions;

namespace NewLMS.UMKM.API.Helpers.Mapping

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