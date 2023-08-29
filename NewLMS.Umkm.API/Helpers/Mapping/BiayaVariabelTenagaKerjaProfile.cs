using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.BiayaVariabelTenagaKerjas;

namespace NewLMS.UMKM.API.Helpers.Mapping

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