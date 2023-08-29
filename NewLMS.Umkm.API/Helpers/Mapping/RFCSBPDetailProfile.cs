using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFCSBPDetails;

namespace NewLMS.Umkm.API.Helpers.Mapping

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