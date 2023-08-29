using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFCSBPDetails;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFCSBPDetailProfile : Profile
    {
        public RFCSBPDetailProfile()
        {
            CreateMap<RFCSBPDetailPostRequestDto, RFCSBPDetail>();
            CreateMap<RFCSBPDetailPutRequestDto, RFCSBPDetail>();
            CreateMap<RFCSBPDetailResponseDto, RFCSBPDetail>().ReverseMap();
        }
    }
}