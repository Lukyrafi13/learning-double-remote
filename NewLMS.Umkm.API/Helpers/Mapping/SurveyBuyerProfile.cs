using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.SurveyBuyers;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class SurveyBuyerProfile : Profile
    {
        public SurveyBuyerProfile()
        {
            CreateMap<SurveyBuyerPostRequestDto, SurveyBuyer>();
            CreateMap<SurveyBuyerPutRequestDto, SurveyBuyer>();
            CreateMap<SurveyBuyerResponseDto, SurveyBuyer>().ReverseMap();
        }
    }
}