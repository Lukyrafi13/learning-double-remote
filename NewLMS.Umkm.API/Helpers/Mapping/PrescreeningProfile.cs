using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.Prescreenings;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class PrescreeningProfile : Profile
    {
        public PrescreeningProfile()
        {
            CreateMap<Prescreening, PrescreeningRACPut>().ReverseMap();
            CreateMap<Prescreening, PrescreeningRACResponse>().ReverseMap();
        }
    }
}
