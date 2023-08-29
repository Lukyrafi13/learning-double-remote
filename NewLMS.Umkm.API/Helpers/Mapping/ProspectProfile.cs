using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.Prospects;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class ProspectProfile : Profile
    {
        public ProspectProfile()
        {
            CreateMap<Prospect, ProspectResponseDto>().ReverseMap();
            CreateMap<ProspectPostRequestDto, Prospect>();
            CreateMap<ProspectPutRequestDto, Prospect>();
        }
    }
}