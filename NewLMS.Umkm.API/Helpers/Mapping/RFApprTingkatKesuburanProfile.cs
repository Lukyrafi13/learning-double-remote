using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFApprTingkatKesuburans;

namespace NewLMS.Umkm.API.Helpers.Mapping

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