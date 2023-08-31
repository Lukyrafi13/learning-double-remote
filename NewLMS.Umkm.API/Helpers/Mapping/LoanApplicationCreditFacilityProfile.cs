using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.LoanApplicationCreditFacilities;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class LoanApplicationCreditFacilityProfile : Profile
    {
        public LoanApplicationCreditFacilityProfile()
        {
            CreateMap<LoanApplicationCreditFacility, LoanApplicationCreditFacilityResponseDto>().ReverseMap();
            CreateMap<LoanApplicationCreditFacilityPostRequestDto, LoanApplicationCreditFacility>();
            CreateMap<LoanApplicationCreditFacilityPutRequestDto, LoanApplicationCreditFacility>();
        }
    }
}