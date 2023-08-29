using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFLoanPurposes;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RFLoanPurposeProfile : Profile
    {
        public RFLoanPurposeProfile()
        {
            CreateMap<RFLoanPurposePostRequestDto, RFLoanPurpose>();
            CreateMap<RFLoanPurposePutRequestDto, RFLoanPurpose>();
            CreateMap<RFLoanPurposeResponseDto, RFLoanPurpose>().ReverseMap();
        }
    }
}