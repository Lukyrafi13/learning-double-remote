using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.AppKeyPersons;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class AppKeyPersonProfile : Profile
    {
        public AppKeyPersonProfile()
        {
            CreateMap<AppKeyPersonPostRequestDto, AppKeyPerson>();
            CreateMap<AppKeyPersonPutRequestDto, AppKeyPerson>();
            CreateMap<AppKeyPersonResponseDto, AppKeyPerson>().ReverseMap();
        }
    }
}