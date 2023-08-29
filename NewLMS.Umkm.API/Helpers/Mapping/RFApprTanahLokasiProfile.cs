using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFApprTanahLokasis;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFApprTanahLokasiProfile : Profile
    {
        public RFApprTanahLokasiProfile()
        {
            CreateMap<RFApprTanahLokasiPostRequestDto, RFApprTanahLokasi>();
            CreateMap<RFApprTanahLokasiPutRequestDto, RFApprTanahLokasi>();
            CreateMap<RFApprTanahLokasiResponseDto, RFApprTanahLokasi>().ReverseMap();
        }
    }
}