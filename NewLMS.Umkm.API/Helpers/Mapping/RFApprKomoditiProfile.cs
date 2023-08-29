using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFApprKomoditis;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFApprKomoditiProfile : Profile
    {
        public RFApprKomoditiProfile()
        {
            CreateMap<RFApprKomoditiPostRequestDto, RFApprKomoditi>();
            CreateMap<RFApprKomoditiPutRequestDto, RFApprKomoditi>();
            CreateMap<RFApprKomoditiResponseDto, RFApprKomoditi>().ReverseMap();
        }
    }
}