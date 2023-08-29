using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.BiayaVariabels;

namespace NewLMS.UMKM.API.Helpers.Mapping

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