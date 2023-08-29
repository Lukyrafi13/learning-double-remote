using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.AppContactPersons;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class AppContactPersonProfile : Profile
    {
        public AppContactPersonProfile()
        {
            CreateMap<AppContactPersonPostRequestDto, AppContactPerson>();
            CreateMap<AppContactPersonPutRequestDto, AppContactPerson>();
            CreateMap<AppContactPersonResponseDto, AppContactPerson>().ReverseMap();
        }
    }
}