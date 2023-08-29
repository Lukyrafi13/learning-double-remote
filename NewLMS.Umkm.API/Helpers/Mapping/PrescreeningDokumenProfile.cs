using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.PrescreeningDokumens;

namespace NewLMS.Umkm.API.Helpers.Mapping

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