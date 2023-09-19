using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationSurvey;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationFieldSurveyProfile : Profile
    {
        public LoanApplicationFieldSurveyProfile()
        {
            CreateMap<LoanApplicationFieldSurveyPostRequest, LoanApplicationFieldSurvey>();
            CreateMap<LoanApplicationFieldSurvey, LoanApplicationFieldSurveyResponse>();
        }
    }
}
