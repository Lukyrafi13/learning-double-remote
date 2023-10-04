using AutoMapper;
using NewLMS.Umkm.Data.Dto.LoanApplicationDuplication;
using NewLMS.Umkm.Data.Dto.MSearch;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class LoanApplicationDuplicationProfile : Profile
    {
        public LoanApplicationDuplicationProfile()
        {
            CreateMap<LoanApplicationDuplication, MSearchResponse>().ReverseMap();

            CreateMap<LoanApplicationDuplication, LoanApplicationDetailResponse>().ReverseMap();

            CreateMap<LoanApplicationDuplication, LoanApplicationDuplicationResponse>().ReverseMap();
        }
    }
}
