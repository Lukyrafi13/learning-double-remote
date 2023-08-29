using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFLoanPurposes;

namespace NewLMS.Umkm.API.Helpers.Mapping

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