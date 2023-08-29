using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SlikRequestObjects;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class SlikRequestObjectProfile : Profile
    {
        public SlikRequestObjectProfile()
        {
            CreateMap<SlikRequestObjectPostRequestDto, SlikRequestObject>();
            CreateMap<SlikRequestObjectPutRequestDto, SlikRequestObject>();
            CreateMap<SlikRequestObjectResponseDto, SlikRequestObject>().ReverseMap();
        }
    }
}