using AutoMapper;
using NewLMS.UMKM.Data.Dto.LoanApplicationFacilities;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
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
