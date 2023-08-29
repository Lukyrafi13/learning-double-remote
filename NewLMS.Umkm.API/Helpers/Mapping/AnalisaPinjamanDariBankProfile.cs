using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.AnalisaPinjamanDariBanks;

namespace NewLMS.UMKM.API.Helpers.Mapping

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