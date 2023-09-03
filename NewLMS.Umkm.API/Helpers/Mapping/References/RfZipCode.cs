using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfZipCodes;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RfZipCodeProfile : Profile
    {
        public RfZipCodeProfile()
        {
            CreateMap<RfZipCode, RfZipCodeResponse>().ReverseMap();
            CreateMap<RfZipCodePostRequest, RfZipCode>();
            CreateMap<RfZipCodePutRequest, RfZipCode>();
        }
    }
}