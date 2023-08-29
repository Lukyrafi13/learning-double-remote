using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFDecisionSKs;

namespace NewLMS.UMKM.API.Helpers.Mapping

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