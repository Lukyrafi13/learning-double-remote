using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.BiayaInvestasis;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class BiayaInvestasiProfile : Profile
    {
        public BiayaInvestasiProfile()
        {
            CreateMap<BiayaInvestasi, BiayaInvestasiResponseDto>().ReverseMap();
            CreateMap<BiayaInvestasiPostRequestDto, BiayaInvestasi>();
            CreateMap<BiayaInvestasiPutRequestDto, BiayaInvestasi>();
        }
    }
}