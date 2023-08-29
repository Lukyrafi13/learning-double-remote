using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfGenders;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RfGenderProfile : Profile
    {
        public RfGenderProfile()
        {
            CreateMap<RfGenderPostRequestDto, RfGender>();
            CreateMap<RfGenderPutRequestDto, RfGender>();
            CreateMap<RfGenderResponseDto, RfGender>().ReverseMap();
        }
    }
}