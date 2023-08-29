using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFZipCodes;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFZipCodeProfile : Profile
    {
        public RFZipCodeProfile()
        {
            CreateMap<RFZipCode, RFZipCodeResponse>().ReverseMap();
            CreateMap<RFZipCodePostRequest, RFZipCode>();
            CreateMap<RFZipCodePutRequest, RFZipCode>();
        }
    }
}