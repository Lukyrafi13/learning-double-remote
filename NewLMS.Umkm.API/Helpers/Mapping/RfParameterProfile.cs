using NewLMS.Umkm.Data.Dto.RfParameters;
using AutoMapper;
using NewLMS.UMKM.Data;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class RfParameterProfile : Profile
    {
        public RfParameterProfile()
        {
            CreateMap<RfParameter, RfParameterResponse>()
                .ForMember(d => d.RfParameterDetails, s => s.MapFrom(d => d.RfParameterDetails));
            CreateMap<RfParameterPostRequest, RfParameter>();
            CreateMap<RfParameterPutRequest, RfParameter>();
        }
    }
}
