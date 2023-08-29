using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.AnalisaPinjamanDariBanks;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class AnalisaPinjamanDariBankProfile : Profile
    {
        public AnalisaPinjamanDariBankProfile()
        {
            CreateMap<AnalisaPinjamanDariBankPostRequestDto, AnalisaPinjamanDariBank>();
            CreateMap<AnalisaPinjamanDariBankPutRequestDto, AnalisaPinjamanDariBank>();
            CreateMap<AnalisaPinjamanDariBankResponseDto, AnalisaPinjamanDariBank>().ReverseMap();
        }
    }
}