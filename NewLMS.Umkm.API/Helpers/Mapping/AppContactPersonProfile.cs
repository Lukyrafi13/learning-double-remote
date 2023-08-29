using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.AppContactPersons;

namespace NewLMS.Umkm.API.Helpers.Mapping

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