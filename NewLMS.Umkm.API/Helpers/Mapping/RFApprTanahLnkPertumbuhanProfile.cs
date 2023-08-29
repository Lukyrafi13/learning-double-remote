using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFApprTanahLnkPertumbuhans;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFApprTanahLnkPertumbuhanProfile : Profile
    {
        public RFApprTanahLnkPertumbuhanProfile()
        {
            CreateMap<RFApprTanahLnkPertumbuhanPostRequestDto, RFApprTanahLnkPertumbuhan>();
            CreateMap<RFApprTanahLnkPertumbuhanPutRequestDto, RFApprTanahLnkPertumbuhan>();
            CreateMap<RFApprTanahLnkPertumbuhanResponseDto, RFApprTanahLnkPertumbuhan>().ReverseMap();
        }
    }
}