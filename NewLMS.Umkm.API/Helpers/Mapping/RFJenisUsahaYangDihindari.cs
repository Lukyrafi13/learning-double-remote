using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfCompanyTypeYangDihindaris;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RfCompanyTypeYangDihindariProfile : Profile
    {
        public RfCompanyTypeYangDihindariProfile()
        {
            CreateMap<RfCompanyTypeYangDihindariPostRequestDto, RfCompanyTypeYangDihindari>();
            CreateMap<RfCompanyTypeYangDihindariPutRequestDto, RfCompanyTypeYangDihindari>();
            CreateMap<RfCompanyTypeYangDihindariResponseDto, RfCompanyTypeYangDihindari>().ReverseMap();
        }
    }
}