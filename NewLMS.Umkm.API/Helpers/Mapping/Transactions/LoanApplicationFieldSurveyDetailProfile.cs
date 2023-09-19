using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationFieldSurveyDetails;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationFieldSurveyDetailProfile : Profile
    {
        public LoanApplicationFieldSurveyDetailProfile()
        {
            CreateMap<LoanApplicationFieldSurveyDetail, LoanApplicationFieldSurveyDetailsResponse>();
            CreateMap<LoanApplicationFieldSurveyDetailsPostRequest, LoanApplicationFieldSurveyDetail>();
            CreateMap<LoanApplicationFIeldSurveyDetailsPutRequest, LoanApplicationFieldSurveyDetail>();
            CreateMap<LoanApplicationFieldSurveyDetailsDeleteRequest, LoanApplicationFieldSurveyDetail>();
        }
    }
}
