using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.Debiturs;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class DebiturProfile : Profile
    {
        public DebiturProfile()
        {
            CreateMap<Debitur, DebiturResponseDto>().ReverseMap();
            CreateMap<DebiturPostRequestDto, Debitur>();
            CreateMap<DebiturPutRequestDto, Debitur>();
        }
    }
}