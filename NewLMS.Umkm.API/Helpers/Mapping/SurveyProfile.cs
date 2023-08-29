using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.Surveys;

namespace NewLMS.UMKM.API.Helpers.Mapping
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
