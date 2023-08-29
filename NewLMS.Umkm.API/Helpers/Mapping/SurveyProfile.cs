using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.Surveys;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class SurveyProfile : Profile
    {
        public SurveyProfile()
        {
            CreateMap<SurveyOTSPut, Survey>().ReverseMap();
            CreateMap<SurveyOTSResponse, Survey>().ReverseMap();
            CreateMap<SurveyVerifikasiPut, Survey>().ReverseMap();
            CreateMap<SurveyVerifikasiResponse, Survey>().ReverseMap();

        }
    }
}
