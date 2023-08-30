using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.DebtorCouples;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class DebtorCoupleProfile : Profile
    {
        public DebtorCoupleProfile()
        {
            // CreateMap<DebtorCouple, DebtorCoupleResponseDto>().ReverseMap();
            CreateMap<DebtorCouplePostRequestDto, DebtorCouple>();
            // CreateMap<DebtorCouplePutRequestDto, DebtorCouple>();
        }
    }
}