using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFGenders;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFGenderProfile : Profile
    {
        public RFGenderProfile()
        {
            CreateMap<RFGenderPostRequestDto, RFGender>();
            CreateMap<RFGenderPutRequestDto, RFGender>();
            CreateMap<RFGenderResponseDto, RFGender>().ReverseMap();
        }
    }
}