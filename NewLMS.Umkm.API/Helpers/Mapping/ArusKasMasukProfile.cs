using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.ArusKasMasuks;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class ArusKasMasukProfile : Profile
    {
        public ArusKasMasukProfile()
        {
            CreateMap<ArusKasMasuk, ArusKasMasukResponseDto>().ReverseMap();
            CreateMap<ArusKasMasukPostRequestDto, ArusKasMasuk>();
            CreateMap<ArusKasMasukPutRequestDto, ArusKasMasuk>();
        }
    }
}