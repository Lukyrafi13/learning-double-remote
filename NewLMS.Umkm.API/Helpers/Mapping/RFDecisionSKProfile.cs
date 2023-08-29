using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFDecisionSKs;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFDecisionSKProfile : Profile
    {
        public RFDecisionSKProfile()
        {
            CreateMap<RFDecisionSKPostRequestDto, RFDecisionSK>();
            CreateMap<RFDecisionSKPutRequestDto, RFDecisionSK>();
            CreateMap<RFDecisionSKResponseDto, RFDecisionSK>().ReverseMap();
        }
    }
}