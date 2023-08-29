using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.ArusKasMasuks;

namespace NewLMS.Umkm.API.Helpers.Mapping

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