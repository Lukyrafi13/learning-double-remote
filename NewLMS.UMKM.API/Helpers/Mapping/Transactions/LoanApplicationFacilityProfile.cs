using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationFacilities;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class LoanApplicationFacilityProfile : Profile
    {
        public LoanApplicationFacilityProfile()
        {
            CreateMap<LoanApplicationFacility, LoanApplicationFacilityResponse>();
            CreateMap<LoanApplicationFacilityRequest, LoanApplicationFacility>();
            CreateMap<LoanApplicationFacilityPostRequest, LoanApplicationFacility>();
            CreateMap<LoanApplicationFacilityDeleteRequest, LoanApplicationFacility>();
        }
    }
}
