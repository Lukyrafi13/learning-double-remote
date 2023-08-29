using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.Prescreenings;

namespace NewLMS.Umkm.API.Helpers.Mapping
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
