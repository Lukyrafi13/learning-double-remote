using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFRelationSurveys;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
