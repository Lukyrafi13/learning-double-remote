using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFAspekPemasarans;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFAspekPemasaranProfile : Profile
    {
        public RFAspekPemasaranProfile()
        {
            CreateMap<RFAspekPemasaranPostRequestDto, RFAspekPemasaran>();
            CreateMap<RFAspekPemasaranPutRequestDto, RFAspekPemasaran>();
            CreateMap<RFAspekPemasaranResponseDto, RFAspekPemasaran>().ReverseMap();
        }
    }
}