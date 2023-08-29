using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.InformasiOmsets;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class InformasiOmsetProfile : Profile
    {
        public InformasiOmsetProfile()
        {
            CreateMap<InformasiOmset, InformasiOmsetResponseDto>().ReverseMap();
            CreateMap<InformasiOmsetPostRequestDto, InformasiOmset>();
            CreateMap<InformasiOmsetPutRequestDto, InformasiOmset>();
        }
    }
}