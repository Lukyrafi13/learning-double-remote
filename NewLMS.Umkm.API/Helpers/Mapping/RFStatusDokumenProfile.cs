using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFStatusDokumens;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RFStatusDokumenProfile : Profile
    {
        public RFStatusDokumenProfile()
        {
            CreateMap<RFStatusDokumenPostRequestDto, RFStatusDokumen>();
            CreateMap<RFStatusDokumenPutRequestDto, RFStatusDokumen>();
            CreateMap<RFStatusDokumenResponseDto, RFStatusDokumen>().ReverseMap();
        }
    }
}
