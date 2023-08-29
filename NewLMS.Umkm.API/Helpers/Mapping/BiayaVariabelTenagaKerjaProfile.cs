using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.BiayaVariabelTenagaKerjas;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class BiayaVariabelTenagaKerjaProfile : Profile
    {
        public BiayaVariabelTenagaKerjaProfile()
        {
            CreateMap<BiayaVariabelTenagaKerja, BiayaVariabelTenagaKerjaResponseDto>().ReverseMap();
            CreateMap<BiayaVariabelTenagaKerjaPostRequestDto, BiayaVariabelTenagaKerja>();
            CreateMap<BiayaVariabelTenagaKerjaPutRequestDto, BiayaVariabelTenagaKerja>();
        }
    }
}