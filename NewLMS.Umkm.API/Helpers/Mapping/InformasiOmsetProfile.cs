using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.InformasiOmsets;

namespace NewLMS.Umkm.API.Helpers.Mapping

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