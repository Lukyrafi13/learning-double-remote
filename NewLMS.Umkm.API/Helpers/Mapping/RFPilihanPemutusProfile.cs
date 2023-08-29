using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFPilihanPemutuss;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFPilihanPemutusProfile : Profile
    {
        public RFPilihanPemutusProfile()
        {
            CreateMap<RFPilihanPemutusPostRequestDto, RFPilihanPemutus>();
            CreateMap<RFPilihanPemutusPutRequestDto, RFPilihanPemutus>();
            CreateMap<RFPilihanPemutusResponseDto, RFPilihanPemutus>().ReverseMap();
        }
    }
}
