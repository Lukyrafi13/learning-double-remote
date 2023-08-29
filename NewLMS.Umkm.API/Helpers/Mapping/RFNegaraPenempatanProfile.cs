using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFNegaraPenempatans;

namespace NewLMS.Umkm.API.Helpers.Mapping

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