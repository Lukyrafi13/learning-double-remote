using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RFJenisAsuransis;

namespace NewLMS.UMKM.API.Helpers.Mapping

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