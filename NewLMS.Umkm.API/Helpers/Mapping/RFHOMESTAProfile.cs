using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFHOMESTAs;

namespace NewLMS.UMKM.API.Helpers.Mapping

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