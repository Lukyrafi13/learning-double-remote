using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RFJenisAsuransis;

namespace NewLMS.Umkm.API.Helpers.Mapping

{
    public class RFJenisAsuransiProfile : Profile
    {
        public RFJenisAsuransiProfile()
        {
            CreateMap<RFJenisAsuransiPostRequestDto, RFJenisAsuransi>();
            CreateMap<RFJenisAsuransiPutRequestDto, RFJenisAsuransi>();
            CreateMap<RFJenisAsuransiResponseDto, RFJenisAsuransi>().ReverseMap();
        }
    }
}