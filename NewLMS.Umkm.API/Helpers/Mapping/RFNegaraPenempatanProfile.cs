using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFNegaraPenempatans;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFNegaraPenempatanProfile : Profile
    {
        public RFNegaraPenempatanProfile()
        {
            CreateMap<RFNegaraPenempatan, RFNegaraPenempatanResponseDto>().ReverseMap();
            CreateMap<RFNegaraPenempatanPostRequestDto, RFNegaraPenempatan>();
            CreateMap<RFNegaraPenempatanPutRequestDto, RFNegaraPenempatan>();
        }
    }
}