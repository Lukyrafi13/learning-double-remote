using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.BiayaVariabels;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class BiayaVariabelProfile : Profile
    {
        public BiayaVariabelProfile()
        {
            CreateMap<BiayaVariabel, BiayaVariabelResponseDto>().ReverseMap();
            CreateMap<BiayaVariabelPostRequestDto, BiayaVariabel>();
            CreateMap<BiayaVariabelPutRequestDto, BiayaVariabel>();
        }
    }
}