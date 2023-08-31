using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.SlikCreditHistorys;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class SlikCreditHistoryProfile : Profile
    {
        public SlikCreditHistoryProfile()
        {
            CreateMap<SlikCreditHistoryPostRequestDto, SlikCreditHistory>();
            CreateMap<SlikCreditHistoryPutRequestDto, SlikCreditHistory>();
            CreateMap<SlikCreditHistoryResponseDto, SlikCreditHistory>().ReverseMap();
        }
    }
}
