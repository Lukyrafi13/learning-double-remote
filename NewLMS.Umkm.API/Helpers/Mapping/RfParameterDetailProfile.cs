using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using AutoMapper;
using NewLMS.UMKM.Data;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RfParameterDetailProfile : Profile
    {
        public RfParameterDetailProfile()
        {
            CreateMap<RfParameterDetail, RfParameterDetailResponse>()
                .ForMember(d => d.RfParameter, s => s.MapFrom(d => d.RfParameter));
            CreateMap<RfParameterDetailPostRequest, RfParameterDetail>();
            CreateMap<RfParameterDetailPutRequest, RfParameterDetail>();
        }
    }
}
