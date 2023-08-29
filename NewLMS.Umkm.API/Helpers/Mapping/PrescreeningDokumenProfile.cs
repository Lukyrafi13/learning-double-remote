using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.PrescreeningDokumens;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class PrescreeningDokumenProfile : Profile
    {
        public PrescreeningDokumenProfile()
        {
            CreateMap<PrescreeningDokumenPostRequestDto, PrescreeningDokumen>();
            CreateMap<PrescreeningDokumenPutRequestDto, PrescreeningDokumen>();
            CreateMap<PrescreeningDokumenResponseDto, PrescreeningDokumen>().ReverseMap();
        }
    }
}