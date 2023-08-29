using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFApprTingkatKesuburans;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFApprTingkatKesuburanProfile : Profile
    {
        public RFApprTingkatKesuburanProfile()
        {
            CreateMap<RFApprTingkatKesuburanPostRequestDto, RFApprTingkatKesuburan>();
            CreateMap<RFApprTingkatKesuburanPutRequestDto, RFApprTingkatKesuburan>();
            CreateMap<RFApprTingkatKesuburanResponseDto, RFApprTingkatKesuburan>().ReverseMap();
        }
    }
}