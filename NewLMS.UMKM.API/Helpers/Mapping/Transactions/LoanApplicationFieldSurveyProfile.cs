using AutoMapper;
using NewLMS.UMKM.Data.Dto.LoanApplicationSurvey;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
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
