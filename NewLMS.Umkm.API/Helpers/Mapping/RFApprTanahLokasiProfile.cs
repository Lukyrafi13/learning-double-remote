using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFApprTanahLokasis;

namespace NewLMS.Umkm.API.Helpers.Mapping

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