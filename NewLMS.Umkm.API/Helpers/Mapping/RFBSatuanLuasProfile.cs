using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFSatuanLuass;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFSatuanLuasProfile : Profile
    {
        public RFSatuanLuasProfile()
        {
            CreateMap<RFSatuanLuasPostRequestDto, RFSatuanLuas>();
            CreateMap<RFSatuanLuasPutRequestDto, RFSatuanLuas>();
            CreateMap<RFSatuanLuasResponseDto, RFSatuanLuas>().ReverseMap();
        }
    }
}