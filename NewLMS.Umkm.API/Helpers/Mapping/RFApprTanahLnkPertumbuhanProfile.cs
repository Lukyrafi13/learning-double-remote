using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFApprTanahLnkPertumbuhans;

namespace NewLMS.Umkm.API.Helpers.Mapping

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