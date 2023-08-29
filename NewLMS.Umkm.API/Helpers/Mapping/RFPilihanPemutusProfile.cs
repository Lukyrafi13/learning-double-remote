using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFPilihanPemutuss;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
