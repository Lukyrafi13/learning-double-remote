using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFHOMESTAs;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFHOMESTAProfile : Profile
    {
        public RFHOMESTAProfile()
        {
            CreateMap<RFHOMESTAPostRequestDto, RFHOMESTA>();
            CreateMap<RFHOMESTAPutRequestDto, RFHOMESTA>();
            CreateMap<RFHOMESTAResponseDto, RFHOMESTA>().ReverseMap();
        }
    }
}