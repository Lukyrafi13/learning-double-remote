using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.BiayaInvestasis;

namespace NewLMS.UMKM.API.Helpers.Mapping

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