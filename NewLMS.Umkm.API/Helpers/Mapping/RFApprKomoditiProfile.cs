using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFApprKomoditis;

namespace NewLMS.Umkm.API.Helpers.Mapping

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