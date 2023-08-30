using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.DebtorEmergencys;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class DebtorEmergencyProfile : Profile
    {
        public DebtorEmergencyProfile()
        {
            // CreateMap<DebtorEmergency, DebtorEmergencyResponseDto>().ReverseMap();
            CreateMap<DebtorEmergencyPostRequestDto, DebtorEmergency>();
            // CreateMap<DebtorEmergencyPutRequestDto, DebtorEmergency>();
        }
    }
}