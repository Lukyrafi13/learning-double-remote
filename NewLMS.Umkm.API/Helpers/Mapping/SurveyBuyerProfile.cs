using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SurveyBuyers;

namespace NewLMS.Umkm.API.Helpers.Mapping

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