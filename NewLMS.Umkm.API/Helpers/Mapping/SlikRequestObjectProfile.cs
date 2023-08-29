using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.SlikRequestObjects;

namespace NewLMS.UMKM.API.Helpers.Mapping

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