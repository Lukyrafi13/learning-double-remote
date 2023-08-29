using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFRelationSurveys;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class RFRelationSurveyProfile : Profile
    {
        public RFRelationSurveyProfile()
        {
            CreateMap<RFRelationSurveyPostRequestDto, RFRelationSurvey>();
            CreateMap<RFRelationSurveyPutRequestDto, RFRelationSurvey>();
            CreateMap<RFRelationSurveyResponseDto, RFRelationSurvey>().ReverseMap();
        }
    }
}
