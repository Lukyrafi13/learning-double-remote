using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.Debtors;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class DebtorProfile : Profile
    {
        public DebtorProfile()
        {
            // CreateMap<Debtor, DebtorResponseDto>().ReverseMap();
            CreateMap<DebtorPostRequestDto, Debtor>();
            // CreateMap<DebtorPutRequestDto, Debtor>();
        }
    }
}