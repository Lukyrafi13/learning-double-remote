using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFSatuanLuass;

namespace NewLMS.Umkm.API.Helpers.Mapping

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