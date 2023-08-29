using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfCategories;

namespace NewLMS.UMKM.API.Helpers.Mapping

{
    public class RfCategoryProfile : Profile
    {
        public RfCategoryProfile()
        {
            CreateMap<RfCategoryPostRequestDto, RfCategory>();
            CreateMap<RfCategoryPutRequestDto, RfCategory>();
            CreateMap<RfCategoryResponseDto, RfCategory>().ReverseMap();
        }
    }
}