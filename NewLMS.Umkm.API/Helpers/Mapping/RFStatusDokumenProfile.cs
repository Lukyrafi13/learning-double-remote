using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFStatusDokumens;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
