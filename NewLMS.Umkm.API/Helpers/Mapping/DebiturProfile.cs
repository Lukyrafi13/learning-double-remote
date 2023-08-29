using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.Debiturs;

namespace NewLMS.UMKM.API.Helpers.Mapping

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