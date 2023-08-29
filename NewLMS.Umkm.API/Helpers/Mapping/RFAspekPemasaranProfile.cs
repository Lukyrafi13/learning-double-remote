using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFAspekPemasarans;

namespace NewLMS.Umkm.API.Helpers.Mapping

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